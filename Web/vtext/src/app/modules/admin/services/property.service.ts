import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { DataCollection, Filter, Property, RequestFilter } from 'src/app/core/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  private apiServer = `${environment.webAPI}${environment.endPoints.property}`;

  constructor(private readonly http: HttpClient) { }

  createProperty(property: Property): Observable<number> {
    return this.http.post<number>(this.apiServer, property);
  }

  findProperty(id: number): Observable<Property> {
    return this.http.get<Property>(`${this.apiServer}/${id}`).pipe(
      map(property => {
        property.images = property.images.map(image => `${environment.webAPI}${image}`);
        return property;
      })
    );
  }

  updatePriperty(property: Property): Observable<void> {
    return this.http.patch<void>(this.apiServer, property);
  }

  getPropertyByFilter(requestFilter: RequestFilter, filter: Filter | undefined): Observable<DataCollection<Property>> {
    const params = this.convertAnyToHttp(filter);
    return this.http.get<DataCollection<Property>>(
      `${this.apiServer}/page/${requestFilter.page}/pagesize/${requestFilter.pageSize}`, { params })
  }

  private convertAnyToHttp(filter: Filter | undefined): HttpParams {
    let params = new HttpParams();
    if (filter) {
      Object.keys(filter)
        .filter(key => filter[key as keyof Filter])
        .forEach(key => params = params.append(key, filter[key as keyof Filter]));
    }
    return params;
  }
}


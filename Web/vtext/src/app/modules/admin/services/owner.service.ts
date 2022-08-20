import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Owner } from 'src/app/core/models';
import { DataCollection } from 'src/app/core/models/data-colection';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  private apiServer = `${environment.webAPI}${environment.endPoints.owner}`;

  constructor(private readonly http: HttpClient) { }

  getOwnerList(page: number, pageZise: number): Observable<DataCollection<Owner>> {
    return this.http.get<DataCollection<Owner>>(`${this.apiServer}/page/${page}/pagesize/${pageZise}`);
  }

  createOwner(owner: Owner): Observable<number> {
    return this.http.post<number>(this.apiServer, owner);
  }

  findOwnerById(id: number): Observable<Owner>{
    return this.http.get<Owner>(`${this.apiServer}/${id}`).pipe(
      map(owner => {
        owner.photo = `${environment.webAPI}${owner.photo}`
        return owner;
      })
    )
  }
}

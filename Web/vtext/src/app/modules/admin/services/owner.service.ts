import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
    return this.http.get<DataCollection<Owner>>(`${this.apiServer}/page/${page}/pagesize/${pageZise}`)
  }
}

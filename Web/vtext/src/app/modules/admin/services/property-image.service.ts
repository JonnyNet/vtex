import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CreatePropertyImages } from 'src/app/core/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropertyImageService {

  private apiServer = `${environment.webAPI}${environment.endPoints.propertyImage}`;

  constructor(private readonly http: HttpClient) { }

  createPropertyImage(create: CreatePropertyImages): Observable<Array<string>> {
    return this.http.post<Array<string>>(this.apiServer, create)
      .pipe(
        map(images => images.map(image => this.mapImage(image))),
      );
  }

  getFindFirstPropertyImage(id: number): Observable<string> {
    return this.http.get<any>(`${this.apiServer}/${id}`).pipe(
      map(({ image }) => this.mapImage(image))
    );
  }

  private mapImage(image: string): string {
    let imageUrl = '';
    if (image) {
      imageUrl = `${environment.webAPI}${image}`;
    }
    return imageUrl;
  }
}

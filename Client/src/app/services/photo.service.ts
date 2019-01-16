import { Injectable } from '@angular/core';
import Photo from '../models/photo';
import { PhotoListComponent } from '../photo-list/photo-list.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor(private http: HttpClient) { }


  search(tag:string){
    let searchUrl = `https://localhost:44339/api/photos`   

    let token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1NDc2NjM0MjgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDIwMDEifQ.m4HjMU8QpQ5hAn7TmQfm5UVwKRHyUV1kZT4-djN30DY';

    return this.http.get<Photo[]>(searchUrl, { headers: new HttpHeaders({'Authorization': 'Bearer ' + token})}).pipe(map((result) => {
      let photos:Photo[] = [];
      for(let i=0,l=result.length;i<l;i++){
          let o = result[i];
          let fp = new Photo( o.title, o.url);  
          photos.push(fp);
      }
      return photos;
    }));  
  }
}

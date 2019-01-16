import { Injectable } from '@angular/core';
import {DemoPhoto} from '../models/demophoto';
import { PhotoListComponent } from '../photo-list/photo-list.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {


  serverUrl:string = `https://localhost:44339/api/photos`  ;
  token:string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1NDc2NjM0MjgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDIwMDEifQ.m4HjMU8QpQ5hAn7TmQfm5UVwKRHyUV1kZT4-djN30DY';
 
  constructor(private http: HttpClient) { }


  search(tag:string){
        
    return this.http.get<DemoPhoto[]>(this.serverUrl,{ headers: new HttpHeaders({'Authorization': 'Bearer ' + this.token})}).pipe(map((result) => {
      let photos:DemoPhoto[] = [];
      for(let i=0,l=result.length;i<l;i++){
          let o = result[i];
          let fp = new DemoPhoto( o.title, o.url);
          fp.id = o.id;  
          photos.push(fp);
      }
      return photos;
    }));  
  }


delete(photo:DemoPhoto)
{
  let deleteUrl = this.serverUrl + photo.id;

  return this.http.delete<DemoPhoto>(deleteUrl, { headers: new HttpHeaders({'Authorization': 'Bearer ' + this.token})}).pipe(map((result) => {
       return result;
  }));  
}


add(photo:DemoPhoto)
{
  let putUrl = this.serverUrl;

  return this.http.post<DemoPhoto>(putUrl, photo, { headers: new HttpHeaders({'Authorization': 'Bearer ' + this.token})}).pipe(map((result) => {
       return result;
  }));  
}

}

import { Injectable } from '@angular/core';
import { FlickerPhoto , FlickerPhotos, RootObject} from '../models/flickrphoto';
import { PhotoListComponent } from '../photo-list/photo-list.component';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlickrService {

  constructor(private http: HttpClient) { }


search(tag:string){
  let searchUrl = `https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=bdaafeafab62267931d920dda27a4f90&tags=${tag}&format=json&nojsoncallback=1`

  return this.http.get<RootObject>(searchUrl).pipe(map((result) => {
    let photos:FlickerPhoto[] = [];
    for(let i=0,l=result.photos.photo.length;i<l;i++){
        let o = result.photos.photo[i];
        let fp = new FlickerPhoto("","");
        fp.id = o.id;
        fp.farm = o.farm;
        fp.secret = o.secret;
        fp.server = o.server;
        fp.title = o.title;
        photos.push(fp);
    }
    return photos;
  }));  
 
}

  /* searchOld(tag:string):Photo[]{
  
    let photos:Photo[]= [
      new Photo("this is Random 1","https://picsum.photos/200/300?image=0"),
      new Photo("this is Random 2","https://picsum.photos/200/300?image=1"),
      new Photo("this is Random 3","https://picsum.photos/200/300?image=2")
    ];

    return photos;
  } */

}

import { Component, OnInit } from '@angular/core';
import {Photo} from '../models/flickrphoto';
import { FlickrService } from '../services/flickr.service';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photo-list',
  templateUrl: './photo-list.component.html',
  styleUrls: ['./photo-list.component.scss']
})
export class PhotoListComponent implements OnInit {

photos:Photo[];

  constructor(private photoService: PhotoService) {

   }

  searchPhotos(tag:string = "sportcar"){
    let data = this.photoService.search(tag).subscribe(
      (response:Photo[]) => {
            this.photos = response;
      }
    );
    console.info(data);
  }

  ngOnInit() {
    this.searchPhotos();
  }

 addImage(title:any, url:any){
  // this.photos.push(new Photo(title.value,url.value));
    
 }

  deletePhoto(photo:Photo){
    this.photos.splice(this.photos.indexOf(photo),1)
  }

}

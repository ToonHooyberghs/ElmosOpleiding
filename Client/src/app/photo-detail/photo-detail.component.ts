import { Component, OnInit } from '@angular/core';
import {DemoPhoto} from '../models/demophoto';

@Component({
  selector: 'app-photo-detail',
  templateUrl: './photo-detail.component.html',
  styleUrls: ['./photo-detail.component.scss']
})
export class PhotoDetailComponent implements OnInit {
url:string = "https://www.vandervalkantwerpen.be/inc/upload/photos/2509/desktop-retina/banner_02.jpg";
title:string ="this is Vander Valk Hotel"

  photo:DemoPhoto = new DemoPhoto("this is Vander Valk Hotel","https://www.vandervalkantwerpen.be/inc/upload/photos/2509/desktop-retina/banner_02.jpg");
  

  constructor() { }

  ngOnInit() {
  }

}

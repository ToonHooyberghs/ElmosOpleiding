import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import Photo from '../models/photo';

@Component({
  selector: 'app-photo-list-item',
  templateUrl: './photo-list-item.component.html',
  styleUrls: ['./photo-list-item.component.scss']
})
export class PhotoListItemComponent implements OnInit {

  @Input() photo:Photo
  @Output() onDelete:EventEmitter<Photo>;
    
  

  constructor() { 
    this.onDelete = new EventEmitter();
  }

  ngOnInit() {
  }

  deletePhoto(){
     this.onDelete.emit(this.photo);
  }

}

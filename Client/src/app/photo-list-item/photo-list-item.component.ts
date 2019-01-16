import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {DemoPhoto} from '../models/demophoto';

@Component({
  selector: 'app-photo-list-item',
  templateUrl: './photo-list-item.component.html',
  styleUrls: ['./photo-list-item.component.scss']
})
export class PhotoListItemComponent implements OnInit {

  @Input() photo:DemoPhoto
  @Output() onDelete:EventEmitter<DemoPhoto>;
    
  

  constructor() { 
    this.onDelete = new EventEmitter();
  }

  ngOnInit() {
  }

  deletePhoto(){
     this.onDelete.emit(this.photo);
  }

}

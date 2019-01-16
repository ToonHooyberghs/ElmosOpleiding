import { NgModule } from '@angular/core';
import {RouterModule, Routes, Router} from '@angular/router';
import { PhotoListComponent } from './photo-list/photo-list.component';
import { PhotoDetailComponent } from './photo-detail/photo-detail.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: PhotoListComponent },
  { path: 'details', component: PhotoDetailComponent }
];

@NgModule({
  declarations: [],
   imports: [  RouterModule.forRoot(routes) ],
   exports: [RouterModule]
})
export class AppRoutingModule { }

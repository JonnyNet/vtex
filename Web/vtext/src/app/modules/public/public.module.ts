import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { SharedModule } from '../shared/shared.module';
import { FilterFormComponent } from './components/filter-form/filter-form.component';
import { PropertyDatailComponent } from './pages/property-datail/property-datail.component';


@NgModule({
  declarations: [
    HomeComponent,
    FilterFormComponent,
    PropertyDatailComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    SharedModule,
  ]
})
export class PublicModule { }

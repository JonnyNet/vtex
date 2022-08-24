import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { URLS } from '../admin/constans/urls';
import { HomeComponent } from './pages/home/home.component';
import { PropertyDatailComponent } from './pages/property-datail/property-datail.component';

const routes: Routes = [
  {
    path: URLS.HOME.PATH,
    component: HomeComponent,
  },
  {
    path: URLS.PROPERTY_DETAIL.PATH,
    component: PropertyDatailComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }

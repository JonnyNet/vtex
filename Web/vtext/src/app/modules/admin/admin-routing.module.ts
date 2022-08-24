import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { URLS } from './constans/urls';
import { OwnerDetailComponent } from './pages/owner-detail/owner-detail.component';
import { OwnerComponent } from './pages/owner/owner.component';
import { PropertyComponent } from './pages/property/property.component';

const routes: Routes = [
  {
    path: URLS.OWNER.PATH,
    component: OwnerComponent,
  },
  {
    path: URLS.OWNER_DETAIL.PATH,
    component: OwnerDetailComponent,
  },
  {
    path: URLS.PROPERTY.PATH,
    component: PropertyComponent,
  },
  {
    path: URLS.PROPERTY_ID.PATH,
    component: PropertyComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

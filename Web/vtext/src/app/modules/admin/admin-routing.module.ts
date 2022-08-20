import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { URLS } from './constans/urls';
import { OwnerComponent } from './pages/owner/owner.component';

const routes: Routes = [
  {
    path: URLS.OWNER.PATH,
    component: OwnerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

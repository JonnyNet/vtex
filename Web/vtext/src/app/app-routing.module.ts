import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { URLS } from './modules/admin/constans/urls';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule),
  },
  {
    path: 'app',
    loadChildren: () => import('./modules/public/public.module').then(m => m.PublicModule),
  },
  {
    path: '**',
    redirectTo: URLS.HOME.FULLPATH,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

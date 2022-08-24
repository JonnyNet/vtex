import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { OwnerComponent } from './pages/owner/owner.component';
import { SharedModule } from '../shared/shared.module';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { getDutchPaginatorIntl } from '../shared/providers/dutch-paginator-intl';
import { CreateOwnerDialogComponent } from './components/create-owner-dialog/create-owner-dialog.component';
import { OwnerDetailComponent } from './pages/owner-detail/owner-detail.component';
import { PropertyComponent } from './pages/property/property.component';
import { UploadImagesDialogComponent } from './components/upload-images-dialog/upload-images-dialog.component';


@NgModule({
  declarations: [
    OwnerComponent,
    CreateOwnerDialogComponent,
    OwnerDetailComponent,
    PropertyComponent,
    UploadImagesDialogComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule,
  ],
  providers: [
    { provide: MatPaginatorIntl, useValue: getDutchPaginatorIntl() },
  ],
})
export class AdminModule { }

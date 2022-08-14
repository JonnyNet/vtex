import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { OwnerComponent } from './pages/owner/owner.component';
import { SharedModule } from '../shared/shared.module';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { getDutchPaginatorIntl } from '../shared/providers/dutch-paginator-intl';


@NgModule({
  declarations: [
    OwnerComponent
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

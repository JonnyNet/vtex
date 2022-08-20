import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';

const components = [
  HeaderComponent,
];

const modules = [
  CommonModule,
  HttpClientModule,
  MatIconModule,
  MatTableModule,
  MatPaginatorModule,
  MatButtonModule 
];

@NgModule({
  declarations: [...components],
  imports: [...modules],
  exports: [
    ...modules,
    ...components,
  ]
})
export class SharedModule { }

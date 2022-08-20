import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Filter, Property } from 'src/app/core/models';
import { AppState } from 'src/app/state/app.state';
import { loadHomeList } from 'src/app/state/public/public.actions';
import * as publicSelector from 'src/app/state/public/public.selector';

const PAGE_SIZE_OPTIONS = [5, 10, 25, 50, 100];
const PAGE_SIZE = 5;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  properties$!: Observable<Property[]>;
  length$!: Observable<number>;

  pageSize = PAGE_SIZE;
  pageSizeOptions = PAGE_SIZE_OPTIONS;

  search: string = "";

  private filter!: Filter;

  constructor(private readonly store: Store<AppState>) { }

  ngOnInit(): void {
    this.length$ = this.store.select(publicSelector.getPropertyLength);
    this.properties$ = this.store.select(publicSelector.getPropertyList);
    this.getPropertyListPerPage();
  }

  onFilter(filter: Filter) {
    this.filter = filter;
    this.pageSize = PAGE_SIZE;
    this.getPropertyListPerPage()
  }

  getPropertyListPerPage(page: number = 1, pageSize: number = this.pageSize, filter: Filter | undefined = this.filter) {
    this.store.dispatch(loadHomeList({
      requestFilter: {
        page,
        pageSize,
      },
      filter
    }));
  }

  onPageEvent(page: PageEvent) {
    this.pageSize = page.pageSize;
    this.getPropertyListPerPage(page.pageIndex + 1, page.pageSize, this.filter)
  }

  onEnter() {
    this.onFilter({ search: this.search } as any)
  }
}

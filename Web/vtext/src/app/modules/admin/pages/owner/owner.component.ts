import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Owner } from 'src/app/core/models';
import { loadOwnerList } from 'src/app/state/admin/admin.actions';
import { getOwnerList } from 'src/app/state/admin/admin.selectors';
import { AppState } from 'src/app/state/app.state';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.scss']
})
export class OwnerComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['id', 'name', 'address', 'birthday', 'action'];
  dataSource = new MatTableDataSource<Owner>();
  resultsLength = 0;
  pageSize = 10;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  subscription = new Array<Subscription>();

  constructor(private readonly store: Store<AppState>) { }

  ngOnInit(): void {
    this.store.select(getOwnerList).subscribe(dataCollection => {
      this.dataSource.data = dataCollection.data;
      this.resultsLength = dataCollection.total;
    });
    this.getOwnerListPerPage();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.subscription.push(this.paginator.page.subscribe((page) => {
      this.getOwnerListPerPage(page.pageIndex + 1, page.pageSize)
    }));
  }

  getOwnerListPerPage(page: number = 1, pageSize: number = this.pageSize) {
    this.store.dispatch(loadOwnerList({
      page,
      pageSize
    }));
  }
}

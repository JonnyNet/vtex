import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Owner } from 'src/app/core/models';
import * as adminActions from 'src/app/state/admin/admin.actions';
import * as adminSelectors from 'src/app/state/admin/admin.selectors';
import { AppState } from 'src/app/state/app.state';
import { CreateOwnerDialogComponent } from '../../components/create-owner-dialog/create-owner-dialog.component';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.scss']
})
export class OwnerComponent implements OnInit, AfterViewInit, OnDestroy {

  displayedColumns: string[] = ['id', 'name', 'address', 'birthday', 'createdAt', 'action'];
  dataSource = new MatTableDataSource<Owner>();
  resultsLength = 0;
  pageSize = 10;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  private subscription = new Array<Subscription>();

  constructor(
    private readonly store: Store<AppState>,
    private readonly dialog: MatDialog) { }

  ngOnInit(): void {
    this.subscription.push(this.store.select(adminSelectors.getOwnerList).subscribe(dataCollection => {
      this.dataSource.data = dataCollection.data;
      this.resultsLength = dataCollection.total;
    }));
    this.getOwnerListPerPage();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  onPageEvent(page: PageEvent) {
    this.getOwnerListPerPage(page.pageIndex + 1, page.pageSize)
  }

  getOwnerListPerPage(page: number = 1, pageSize: number = this.pageSize) {
    this.store.dispatch(adminActions.loadOwnerList({
      page,
      pageSize
    }));
  }

  openCreateOwnerDialog() {
    const dialogRef = this.dialog.open(CreateOwnerDialogComponent, {
      width: '30%',
    })
    this.subscription.push(dialogRef.afterClosed().subscribe((result: Owner) => {
      this.store.dispatch(adminActions.createOwner(result))
    }));
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe())
  }
}

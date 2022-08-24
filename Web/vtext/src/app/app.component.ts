import { AfterContentChecked, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { AppState } from './state/app.state';
import { getLoading, getMessage } from './state/app/app.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterContentChecked, OnDestroy {

  loading$!: Observable<boolean>;
  private subscription!: Subscription;

  constructor(
    private readonly store: Store<AppState>,
    private readonly snackBar: MatSnackBar,
    private readonly cdref: ChangeDetectorRef) { }


  ngOnInit(): void {
    this.loading$ = this.store.select(getLoading)
    this.subscription = this.store.select(getMessage).subscribe(message => {
      if (message) {
        this.snackBar.open(message, 'X', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 5000,
        });
      }
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  ngAfterContentChecked(): void {
    this.cdref.detectChanges();
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, Subscription, take } from 'rxjs';
import { ID } from 'src/app/core/constans/constans';
import { CreatePropertyImages, Property } from 'src/app/core/models';
import * as adminActions from 'src/app/state/admin/admin.actions';
import * as adminSelectors from 'src/app/state/admin/admin.selectors';
import { AppState } from 'src/app/state/app.state';
import { UploadImagesDialogComponent } from '../../components/upload-images-dialog/upload-images-dialog.component';
import { URLS } from '../../constans/urls';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit, OnDestroy {

  property!: Property;
  images$!: Observable<string[]>;
  showImages = false;
  private subscription!: Subscription;

  constructor(
    private readonly store: Store<AppState>,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly dialog: MatDialog) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.params[ID];
    if (id) {
      const numberId = Number(id);
      this.store.select(adminSelectors.getProperty)
        .pipe(take(2))
        .subscribe(property => {
          this.property = property;
        });
      this.images$ = this.store.select(adminSelectors.getPropertyImages);
      this.store.dispatch(adminActions.findProperty({ id: numberId }))
      this.showImages = true;
    }
    else {
      this.store.select(adminSelectors.getOwnerById)
        .pipe(take(1))
        .subscribe(owner => {
          if (!owner) {
            this.router.navigate([URLS.OWNER.FULLPATH]);
          } else {
            this.property = new Property(owner.id);
          }
        });
    }
  }

  onSubmit(property: any) {
    property.ownerId = this.property.ownerId;
    if (property.id) {
      this.store.dispatch(adminActions.updateProperty(property));
    } else {
      this.store.dispatch(adminActions.createProperty(property));
      this.showImages = true;
    }
  }

  openUploadImagesDialog() {
    const dialogRef = this.dialog.open(UploadImagesDialogComponent, {
      width: '20%',
    })
    this.subscription = dialogRef.afterClosed().subscribe((images: any) => {
      if (images.length) {
        const request: CreatePropertyImages = {
          propertyId: this.property.id,
          images
        };
        this.store.dispatch(adminActions.createPropertyImage(request));
      }
    });
  }

  ngOnDestroy(): void {
    this.store.dispatch(adminActions.clearProperty());
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}

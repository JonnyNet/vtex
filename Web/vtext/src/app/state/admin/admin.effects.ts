import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { catchError, EMPTY, exhaustMap, map, mergeMap, switchMap, tap, delay } from 'rxjs';
import { CREATE_PROPERTY_MESSAGE, UPDATE_PROPERTY_MESSAGE } from 'src/app/core/constans/constans';
import { CreatePropertyImages, Owner, Property } from 'src/app/core/models';
import { OwnerService } from 'src/app/modules/admin/services/owner.service';
import { PropertyImageService } from 'src/app/modules/admin/services/property-image.service';
import { PropertyService } from 'src/app/modules/admin/services/property.service';
import { AppState } from '../app.state';
import { setLoadingSpinner, setSnackBarMessage } from '../app/app.actions';
import {
  createdProperty, createdPropertyImage, createOwner, createProperty, createPropertyImage, findFirstPropertyImage, findOwner, findProperty, foundFirstPropertyImage, foundOwner, foundProperty, loadedOwnerList, loadOwnerList, updatedProperty, updateProperty
} from './admin.actions';
import { getRequestFilter } from './admin.selectors';

@Injectable({
  providedIn: 'root'
})
export class AdminEffects {

  constructor(
    private readonly actions$: Actions,
    private readonly store$: Store<AppState>,
    private readonly ownerService: OwnerService,
    private readonly propertyService: PropertyService,
    private readonly propertyImageService: PropertyImageService,
  ) { }

  getOwnerList$ = createEffect(() => this.actions$.pipe(
    ofType(loadOwnerList),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    mergeMap(filter => this.ownerService.getOwnerList(filter.page, filter.pageSize).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(ownerList => loadedOwnerList(ownerList)),
      catchError(() => EMPTY)
    ))
  ));

  createOwner$ = createEffect(() => this.actions$.pipe(
    ofType(createOwner),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    exhaustMap((owner: Owner) => this.ownerService.createOwner(owner).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      switchMap(() => this.store$.select(getRequestFilter)),
      map((filter) => loadOwnerList(filter)),
      catchError(() => EMPTY)
    ))
  ));

  findOwnerById$ = createEffect(() => this.actions$.pipe(
    ofType(findOwner),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    mergeMap(({ id }) => this.ownerService.findOwnerById(id).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(owner => foundOwner(owner)),
      catchError(() => EMPTY)
    ))
  ));

  createProperty$ = createEffect(() => this.actions$.pipe(
    ofType(createProperty),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    exhaustMap((property: Property) => this.propertyService.createProperty(property).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(id => createdProperty({ ...property, id })),
      tap(() => this.store$.dispatch(setSnackBarMessage({ message: CREATE_PROPERTY_MESSAGE }))),
      catchError(() => EMPTY)
    ))
  ));

  findFirstPropertyImage$ = createEffect(() => this.actions$.pipe(
    ofType(findFirstPropertyImage),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    mergeMap(({ id }) => this.propertyImageService.getFindFirstPropertyImage(id).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(image => foundFirstPropertyImage({ id, image })),
      catchError(() => EMPTY)
    ))
  ));

  findProperty$ = createEffect(() => this.actions$.pipe(
    ofType(findProperty),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    mergeMap(({ id }) => this.propertyService.findProperty(id).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(property => foundProperty(property)),
      catchError(() => EMPTY)
    ))
  ));

  createPropertyImage$ = createEffect(() => this.actions$.pipe(
    ofType(createPropertyImage),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    exhaustMap((request: CreatePropertyImages) => this.propertyImageService.createPropertyImage(request).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(images => createdPropertyImage({ images })),
      catchError(() => EMPTY)
    ))
  ));

  updateProperty$ = createEffect(() => this.actions$.pipe(
    ofType(updateProperty),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    mergeMap((property: Property) => this.propertyService.updatePriperty(property).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(() => updatedProperty(property)),
      tap(() => this.store$.dispatch(setSnackBarMessage({ message: UPDATE_PROPERTY_MESSAGE }))),
      catchError(() => EMPTY)
    ))
  ));
}
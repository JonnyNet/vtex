import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { catchError, EMPTY, exhaustMap, map, tap } from 'rxjs';
import { PropertyService } from "src/app/modules/admin/services/property.service";
import { AppState } from "../app.state";
import { setLoadingSpinner } from "../app/app.actions";
import { loadedHomeList, loadHomeList, findProperty, foundProperty } from './public.actions';

@Injectable({
  providedIn: 'root'
})
export class PublicEffects {

  constructor(
    private readonly actions$: Actions,
    private readonly store$: Store<AppState>,
    private readonly propertyService: PropertyService,) { }

  loadHomeList$ = createEffect(() => this.actions$.pipe(
    ofType(loadHomeList),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    exhaustMap(({ requestFilter, filter }) => this.propertyService.getPropertyByFilter(requestFilter, filter).pipe(
      map(colection => loadedHomeList(colection)),
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      catchError(() => EMPTY)
    ))
  ));


  findProperty$ = createEffect(() => this.actions$.pipe(
    ofType(findProperty),
    tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: true }))),
    exhaustMap(({ id }) => this.propertyService.findProperty(id).pipe(
      tap(() => this.store$.dispatch(setLoadingSpinner({ isLoading: false }))),
      map(property => foundProperty(property)),
      catchError(() => EMPTY)
    ))
  ));

}
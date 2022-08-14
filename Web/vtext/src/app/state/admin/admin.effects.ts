import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, EMPTY, map, mergeMap } from 'rxjs';
import { OwnerService } from 'src/app/modules/admin/services/owner.service';
import { loadOwnerList, loadedOwnerList } from './admin.actions'

@Injectable({
  providedIn: 'root'
})
export class AdminEffects {

  getOwnerList$ = createEffect(() => this.actions$.pipe(
    ofType(loadOwnerList),
    mergeMap(filter => this.service.getOwnerList(filter.page, filter.pageSize).pipe(
      map(ownerList => loadedOwnerList(ownerList)),
      catchError(() => EMPTY)
    ))
  ));

  constructor(
    private readonly actions$: Actions,
    private readonly service: OwnerService
  ) { }
}
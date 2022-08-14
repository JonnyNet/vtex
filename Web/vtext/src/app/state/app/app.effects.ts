import { Injectable } from "@angular/core";
import { Actions, createEffect } from "@ngrx/effects";
import { filter, map } from "rxjs";
import { showSpinner } from "./app.actions";

@Injectable()
export class AppEffects {

  constructor(private actions$: Actions) { }

  showLoader$ = this.actions$.pipe(
    map(action => showSpinner({ value: action }))
  )

}
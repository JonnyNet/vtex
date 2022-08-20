import { createReducer, on } from "@ngrx/store";
import { showSpinner } from './app.actions'

export const spinnerState: boolean = false;

export const appReducer = createReducer(
  spinnerState,
  on(showSpinner, (_oldState, newState) => {
    return newState.value;
  }),
);
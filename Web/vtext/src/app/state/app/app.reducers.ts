import { createReducer, on } from "@ngrx/store";
import { GlobalState } from "src/app/core/models";
import { setLoadingSpinner, setSnackBarMessage } from './app.actions'

export const spinnerState: GlobalState = {
  isLoading: false,
  snackBarMessage: "",
};

export const appReducer = createReducer(
  spinnerState,
  on(setLoadingSpinner, (state, { isLoading }) => {
    return { ...state, isLoading }
  }),
  on(setSnackBarMessage, (state, { message }) => {
    return { ...state, snackBarMessage: message }
  })
);
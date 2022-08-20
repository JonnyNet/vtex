import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";


const getAppState = (state: AppState) => state.global

export const getLoading = createSelector(
  getAppState, (state) => state.isLoading
)

export const getMessage = createSelector(
  getAppState, (state) => state.snackBarMessage
)

import { createAction, props } from "@ngrx/store";

export const SET_LOADING_SPINNER = "[UI] Set loading spinner";
export const SET_SNACKBAR_MESSAGE = "[UI] Set SnackBar Message";

export const setLoadingSpinner = createAction(
  SET_LOADING_SPINNER,
  props<{ isLoading: boolean }>()
);

export const setSnackBarMessage = createAction(
  SET_SNACKBAR_MESSAGE,
  props<{ message: string }>()
);

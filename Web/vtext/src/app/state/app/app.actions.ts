import { createAction, props } from "@ngrx/store";

export const SHOW_SPINNER = "[UI] Show loading spinner";
export const HIDE_SPINNER = "[UI] Hide loading spinner";

export const showSpinner = createAction(
  SHOW_SPINNER,
  props<{ value: boolean }>()
);

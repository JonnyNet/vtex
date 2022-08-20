import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";

export const getPropertyDataCollection = (state: AppState) => state.public.collection
export const getPublicState = (state: AppState) => state.public

export const getPropertyList = createSelector(
  getPropertyDataCollection,
  ({ data }) => data
);

export const getPropertyLength = createSelector(
  getPropertyDataCollection,
  ({ total }) => total
);

export const getRequestFilter = createSelector(
  getPropertyDataCollection,
  ({ page, pageSize }) => ({ page, pageSize })
);

export const getProperty = createSelector(
  getPublicState,
  (state) => state.property
);

export const getPropertyImages = createSelector(
  getPublicState,
  ({ property }) => {
    let images = new Array<string>();
    if (property) {
      images = property.images;
    }
    return images;
  }
);
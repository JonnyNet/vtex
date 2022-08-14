import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";

export const getOwnerDataCollection = (state: AppState) => state.owners

export const getOwnerList = createSelector(
  getOwnerDataCollection,
  (dataCollection) => ({ total: dataCollection.total, data: dataCollection.data })
);
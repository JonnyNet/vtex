import { createReducer, on } from "@ngrx/store";
import { DataCollection, Owner } from "src/app/core/models";
import { loadOwnerList, loadedOwnerList } from "./admin.actions";

export const ownerState: DataCollection<Owner> = {
  page: 0,
  pageSize: 0,
  total: 0,
  totalpages: 0,
  data: []
};

export const ownerReducer = createReducer(
  ownerState,
  on(loadOwnerList, (state) => {
    return state;
  }),
  on(loadedOwnerList, (state, dataCollection) => {
    return { ...state, ...dataCollection }
  })
);
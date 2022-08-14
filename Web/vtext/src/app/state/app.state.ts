import { ActionReducerMap } from "@ngrx/store";
import { DataCollection, Owner } from "../core/models";
import { ownerReducer } from "./admin/admin.reducers";
import { appReducer } from "./app/app.reducers";

export interface AppState {
  isLoading: boolean,
  owners: DataCollection<Owner>
}

export const ROOT_REDUCERS: ActionReducerMap<AppState> = {
  isLoading: appReducer,
  owners: ownerReducer
};
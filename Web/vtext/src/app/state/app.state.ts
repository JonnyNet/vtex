import { routerReducer, RouterReducerState } from "@ngrx/router-store";
import { ActionReducerMap } from "@ngrx/store";
import { GlobalState, OwnerState } from "../core/models";
import { PublicState } from "../core/models/public-state";
import { ownerReducer } from "./admin/admin.reducers";
import { appReducer } from "./app/app.reducers";
import { publicReducer } from "./public/public.reducers";

export interface AppState {
  global: GlobalState,
  owners: OwnerState,
  public: PublicState,
  router: RouterReducerState<any>
}

export const ROOT_REDUCERS: ActionReducerMap<AppState> = {
  global: appReducer,
  owners: ownerReducer,
  public: publicReducer,
  router: routerReducer,
};
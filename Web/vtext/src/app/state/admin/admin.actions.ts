import { createAction, props } from "@ngrx/store";
import { Owner, RequestFilter } from "src/app/core/models";
import { DataCollection } from "src/app/core/models/data-colection";


export const LOAD_OWNER_LIST = '[Owner List] Load Owner List';
export const LOADED_OWNER_LIST = '[Owner List] Loaded Owner List';


export const loadOwnerList = createAction(
  LOAD_OWNER_LIST,
  props<RequestFilter>()
);

export const loadedOwnerList = createAction(
  LOADED_OWNER_LIST,
  props<DataCollection<Owner>>()
);
import { createAction, props } from "@ngrx/store";
import { DataCollection, Filter, Find, Property, RequestFilter } from "src/app/core/models";

export enum PublicListActions {
  LOAD_HOME_LIST = '[Home List] Load Home List',
  LOADED_HOME_LIST = '[Home List] Loaded Home List',
  FIND_PROPERTY = '[Property Detail] Find Property Detail',
  FOUND_PROPERTY = '[Property Detail] Found Property Detail',
}

export const loadHomeList = createAction(
  PublicListActions.LOAD_HOME_LIST,
  props<{ requestFilter: RequestFilter, filter: Filter | undefined }>()
);

export const loadedHomeList = createAction(
  PublicListActions.LOADED_HOME_LIST,
  props<DataCollection<Property>>()
);

export const findProperty = createAction(
  PublicListActions.FIND_PROPERTY,
  props<Find>(),
)

export const foundProperty = createAction(
  PublicListActions.FOUND_PROPERTY,
  props<Property>(),
)
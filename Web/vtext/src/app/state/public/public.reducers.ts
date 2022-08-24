import { createReducer, on } from "@ngrx/store";
import { PublicState } from "src/app/core/models/public-state";
import { loadedHomeList, foundProperty } from './public.actions';

export const publicState: PublicState = {
  collection: {
    page: 0,
    pageSize: 0,
    total: 0,
    totalpages: 0,
    data: []
  },
  property: undefined as any,
  propertyMainImage: [],
};

export const publicReducer = createReducer(
  publicState,
  on(loadedHomeList, (state, collection) => {
    return { ...state, collection };
  }),
  on(foundProperty, (state, property) => {
    return { ...state, property }
  }),
);
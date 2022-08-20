import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";

export const getOwnerDataCollection = (state: AppState) => state.owners.collection
export const getOwners = (state: AppState) => state.owners


export const getOwnerList = createSelector(
  getOwnerDataCollection,
  ({ total, data }) => ({ total, data })
);

export const getRequestFilter = createSelector(
  getOwnerDataCollection,
  ({ page, pageSize }) => ({ page, pageSize })
);

export const getOwnerById = createSelector(
  getOwners,
  (state) => state.owner
);

export const getProperty = createSelector(
  getOwners,
  (state) => state.property
);

export const getFirstPropertyImageById = (id: number) => createSelector(
  getOwners,
  ({ propertyMainImage }) => {
    const property = propertyMainImage.find(x => x.propertyId === id);
    let image = '';
    if (property) {
      image = property.image;
    }
    return image;
  }
);

export const getPropertyImages = createSelector(
  getOwners,
  ({ property }) => {
    let images = new Array<string>();
    if(property){
      images = property.images;
    }
    return images;
  }
);
import { createReducer, on } from "@ngrx/store";
import { OwnerState } from "src/app/core/models";
import { PropertyMainImage } from "src/app/core/models/property-main-image";
import { clearProperty, createdProperty, createdPropertyImage, foundFirstPropertyImage, foundOwner, foundProperty, loadedOwnerList, updatedProperty } from "./admin.actions";

export const ownerState: OwnerState = {
  collection: {
    page: 0,
    pageSize: 0,
    total: 0,
    totalpages: 0,
    data: []
  },
  owner: undefined as any,
  property: undefined as any,
  propertyMainImage: [],
};

export const ownerReducer = createReducer(
  ownerState,
  on(loadedOwnerList, (state, collection) => {
    return { ...state, collection }
  }),
  on(foundOwner, (state, owner) => {
    return { ...state, owner }
  }),
  on(createdProperty, (state, property) => {
    const owner = { ...state.owner };
    owner.properties = [...owner.properties, property];
    return { ...state, owner }
  }),
  on(foundFirstPropertyImage, (state, { id, image }) => {
    if (!image) {
      return state;
    }
    const mainImage: PropertyMainImage = { propertyId: id, image };
    const propertyMainImage = [...state.propertyMainImage, mainImage];
    return { ...state, propertyMainImage };

  }),
  on(foundProperty, (state, property) => {
    return { ...state, property }
  }),
  on(clearProperty, (state) => {
    return { ...state, property: undefined as any }
  }),
  on(createdPropertyImage, (state, { images }) => {
    const property = { ...state.property };
    property.images = [...property.images, ...images];
    return { ...state, property }
  }),
  on(updatedProperty, (state, updateProperty) => {
    const property = { ...state.property, updateProperty };
    return { ...state, property }
  })
);
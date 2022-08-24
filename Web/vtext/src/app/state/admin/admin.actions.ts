import { createAction, props } from "@ngrx/store";
import { CreatePropertyImages, Find, Owner, Property, RequestFilter } from "src/app/core/models";
import { DataCollection } from "src/app/core/models/data-colection";

export enum OwnerListActions {
  LOAD_OWNER_LIST = '[Owner List] Load Owner List',
  LOADED_OWNER_LIST = '[Owner List] Loaded Owner List',
  CREATE_OWNER = '[Owner List] Create Owner',
  CREATED_OWNER = '[Owner List] Created Owner',
  FIND_OWNER = '[Owner Detail] Find Owner',
  FOUND_OWNER = '[Owner Detail] Found Owner',
  FIND_FIRST_PROPERTY_IMAGE = '[Owner Detail] Find First Property Image',
  FOUND_FIRST_PROPERTY_IMAGE = '[Owner Detail] Found First Property Image',
  CREATE_PROPERTY = '[Property View] Create Property',
  CREATED_PROPERTY = '[Property View] Created Property',
  FIND_PROPERTY = '[Property View] Find Property',
  FOUND_PROPERTY = '[Property View] Found Property',
  CLEAR_PROPERTY = '[Property View] Clear Property',
  CREATE_PROPERTY_IMAGE = '[Property View] Create Property Image',
  CREATED_PROPERTY_IMAGE = '[Property View] Created Property Image',
  UPDATE_PROPERTY_IMAGE = '[Property View] Update Property Image',
  UPDATED_PROPERTY_IMAGE = '[Property View] Updated Property Image',
}


export const loadOwnerList = createAction(
  OwnerListActions.LOAD_OWNER_LIST,
  props<RequestFilter>()
);

export const loadedOwnerList = createAction(
  OwnerListActions.LOADED_OWNER_LIST,
  props<DataCollection<Owner>>()
);

export const createOwner = createAction(
  OwnerListActions.CREATE_OWNER,
  props<Owner>()
);

export const findOwner = createAction(
  OwnerListActions.FIND_OWNER,
  props<Find>()
);

export const foundOwner = createAction(
  OwnerListActions.FOUND_OWNER,
  props<Owner>()
);

export const createProperty = createAction(
  OwnerListActions.CREATE_PROPERTY,
  props<Property>()
)

export const createdProperty = createAction(
  OwnerListActions.CREATED_PROPERTY,
  props<Property>()
)

export const findFirstPropertyImage = createAction(
  OwnerListActions.FIND_FIRST_PROPERTY_IMAGE,
  props<Find>(),
)

export const foundFirstPropertyImage = createAction(
  OwnerListActions.FOUND_FIRST_PROPERTY_IMAGE,
  props<{ id: number, image: string }>(),
)

export const findProperty = createAction(
  OwnerListActions.FIND_PROPERTY,
  props<Find>(),
)

export const foundProperty = createAction(
  OwnerListActions.FOUND_PROPERTY,
  props<Property>(),
)

export const clearProperty = createAction(
  OwnerListActions.CLEAR_PROPERTY
)

export const createPropertyImage = createAction(
  OwnerListActions.CREATE_PROPERTY_IMAGE,
  props<CreatePropertyImages>(),
)

export const createdPropertyImage = createAction(
  OwnerListActions.CREATED_PROPERTY_IMAGE,
  props<{ images: string[] }>(),
)

export const updateProperty = createAction(
  OwnerListActions.UPDATE_PROPERTY_IMAGE,
  props<Property>()
);

export const updatedProperty = createAction(
  OwnerListActions.UPDATED_PROPERTY_IMAGE,
  props<Property>()
);
import { DataCollection } from "./data-colection";
import { Owner } from "./owner";
import { Property } from "./property";
import { PropertyMainImage } from "./property-main-image";

export interface OwnerState {
  collection: DataCollection<Owner>,
  owner: Owner,
  property: Property
  propertyMainImage: PropertyMainImage[]
}
import { DataCollection } from "./data-colection";
import { Property } from "./property";
import { PropertyMainImage } from "./property-main-image";

export interface PublicState {
  collection: DataCollection<Property>,
  property: Property
  propertyMainImage: PropertyMainImage[]
}
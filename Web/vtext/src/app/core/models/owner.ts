import { Property } from "./property"

export interface Owner {
  id: number,
  name: string
  address: string,
  photo: string,
  birthday: Date,
  createdAt: Date,

  properties: Property[],
}
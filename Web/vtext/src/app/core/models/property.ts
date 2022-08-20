export class Property {
  id!: number;
  ownerId!: number;
  name!: string;
  address!: string;
  price!: number;
  year!: number;
  codeInternal!: string;
  bedRooms!: number;
  bathRooms!: number;
  area!: number;
  parkingLot!: number;

  images!: string[];

  constructor(ownerId: number){
    this.ownerId = ownerId;
  }
}
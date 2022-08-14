export interface DataCollection<T> {
  page: number,
  pageSize: number,
  total: number,
  totalpages: number,
  data: T[]
}
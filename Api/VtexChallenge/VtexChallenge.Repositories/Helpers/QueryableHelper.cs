using Microsoft.EntityFrameworkCore;
using System.Linq;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Helpers
{
	public static class QueryableHelper
	{
		public static IQueryable<Property> WhereBedrooms(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (requestFilter.Bedrooms != null)
			{
				int bedrooms = requestFilter.Bedrooms.Value;
				if (bedrooms < 4)
				{
					query = query.Where(x => x.BedRooms == bedrooms);
				}
				else
				{
					query = query.Where(x => x.BedRooms >= bedrooms);
				}
			}
			return query;
		}

		public static IQueryable<Property> WhereBathrooms(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (requestFilter.Bathrooms != null)
			{
				int bathrooms = requestFilter.Bathrooms.Value;
				if (bathrooms < 4)
				{
					query = query.Where(x => x.BathRooms == bathrooms);
				}
				else
				{
					query = query.Where(x => x.BathRooms >= bathrooms);
				}
			}
			return query;
		}

		public static IQueryable<Property> WhereParkingLot(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (requestFilter.ParkingLot != null)
			{
				int parkingLot = requestFilter.ParkingLot.Value;
				if (parkingLot < 4)
				{
					query = query.Where(x => x.ParkingLot == parkingLot);
				}
				else
				{
					query = query.Where(x => x.ParkingLot >= parkingLot);
				}
			}
			return query;
		}

		public static IQueryable<Property> WhereArea(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (requestFilter.AreaFrom != null && requestFilter.AreaTo != null)
			{
				var areaFrom = requestFilter.AreaFrom.Value;
				var areaTo = requestFilter.AreaTo.Value;

				query = query.Where(x => areaFrom >= x.Area && x.Area <= areaTo);
			}
			return query;
		}

		public static IQueryable<Property> WherePrice(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (requestFilter.PriceFrom != null && requestFilter.PriceTo != null)
			{
				var priceFrom = requestFilter.PriceFrom.Value;
				var priceTo = requestFilter.PriceTo.Value;

				query = query.Where(x => priceFrom >= x.Price && x.Price <= priceTo);
			}
			return query;
		}

		public static IQueryable<Property> WhereSearch(IQueryable<Property> query, PropertyFilter requestFilter)
		{
			if (!string.IsNullOrEmpty(requestFilter.Search))
			{
				query = query.Where(x =>
				EF.Functions.Like(x.Name, $"%{requestFilter.Search}%") ||
				EF.Functions.Like(x.Address, $"%{requestFilter.Search}%"));
			}
			return query;
		}
	}
}

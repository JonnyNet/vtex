using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Common.Collections;
using VtexChallenge.Repositories.Extensions;
using VtexChallenge.Repositories.Helpers;

namespace VtexChallenge.Repositories.Repositories.PropertyRepositories
{
	public class PropertyQuerysRepository : IPropertyQuerysRepository
	{
		private readonly IDbContext _dbContex;

		public PropertyQuerysRepository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public Task<Property> FindAsync(int idEntity)
			=> _dbContex.Properties.FirstOrDefaultAsync(x => x.Id == idEntity);

		public Task<DataCollection<Property>> GetAll(PropertyFilter requestFilter)
		{
			var query = _dbContex.Properties.AsQueryable();

			query = QueryableHelper.WhereBedrooms(query, requestFilter);
			query = QueryableHelper.WhereBathrooms(query, requestFilter);
			query = QueryableHelper.WhereParkingLot(query, requestFilter);
			query = QueryableHelper.WhereArea(query, requestFilter);
			query = QueryableHelper.WherePrice(query, requestFilter);
			query = QueryableHelper.WhereSearch(query, requestFilter);


			return query
				.OrderByDescending(x => x.UpdatedAt)
				.Select(x => GetSelectProperty(x))
				.GetPagedAsync(requestFilter.Page, requestFilter.PageSize);
		}


		public async Task<IEnumerable<Property>> GetPropertiesByOwnerId(int ownerId)
		{
			var propertyList = await _dbContex.Properties
				.OrderByDescending(x => x.UpdatedAt)
				.Select(x => GetSelectProperty(x))
				.Where(x => x.OwnerId == ownerId)
				.ToListAsync();
			return propertyList;
		}

		private static Property GetSelectProperty(Property x) => new()
		{
			Id = x.Id,
			OwnerId = x.OwnerId,
			Name = x.Name,
			Price = x.Price,
			BedRooms = x.BedRooms,
			BathRooms = x.BathRooms,
			Area = x.Area,
			ParkingLot = x.ParkingLot
		};
	}
}

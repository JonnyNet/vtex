using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;
using VtexChallenge.Repositories.Extensions;

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

		public Task<DataCollection<Property>> GetAll(RequestFilter requestFilter)
		{
			return _dbContex.Properties
				.OrderByDescending(x => x.Id)
				.GetPagedAsync(requestFilter.Page, requestFilter.PageSize);
		}
	}
}

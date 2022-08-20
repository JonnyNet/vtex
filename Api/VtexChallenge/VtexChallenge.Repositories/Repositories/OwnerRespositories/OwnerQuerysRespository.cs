using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;
using VtexChallenge.Repositories.Extensions;

namespace VtexChallenge.Repositories.Repositories.OwnerRespositories
{
	public class OwnerQuerysRespository : IOwnerQuerysRespository
	{
		private readonly IDbContext _dbContex;

		public OwnerQuerysRespository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public Task<Owner> FindAsync(int idEntity)
			=> _dbContex.Owners.FirstOrDefaultAsync(x => x.Id == idEntity);


		public Task<DataCollection<Owner>> GetAll(RequestFilter requestFilter)
		{
			return _dbContex.Owners
				.OrderByDescending(x => x.Id)
				.GetPagedAsync(requestFilter.Page, requestFilter.PageSize);
		}
	}
}

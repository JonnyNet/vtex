using System;
using System.Linq.Expressions;

namespace VtexChallenge.Entities.Specifications
{
	public abstract class Specification<T>
	{
		public abstract Expression<Func<T, bool>> Expression { get; set; }
		public bool ISSatisfiedBy(T entity)
		{
			Func<T, bool> ExpressionDelegate = Expression.Compile();
			return ExpressionDelegate(entity);
		}
	}
}

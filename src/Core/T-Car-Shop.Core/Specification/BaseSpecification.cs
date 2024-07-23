using System.Linq.Expressions;

namespace T_Car_Shop.Core.Specification
{
	public class BaseSpecification<T> : ISpecification<T>
	{
		public BaseSpecification()
		{

		}
		public BaseSpecification(Expression<Func<T, bool>> query)
		{
			Query = query;
		}

		public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
		public Expression<Func<T, bool>> Query { get; }
		public Expression<Func<T, object>> OrderBy { get; private set; }
		public Expression<Func<T, object>> OrderByDescending { get; private set; }
		protected void AddInclude(Expression<Func<T, object>> include)
		{
			Includes.Add(include);
		}
		protected void AddOrderBy(Expression<Func<T, object>> orderBy)
		{
			OrderBy = orderBy;
		}
		protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
		{
			OrderByDescending = orderByDescending;
		}
	}
}

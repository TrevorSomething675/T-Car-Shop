using T_Car_Shop.Core.Exceptions.DomainExceptions;
using System.Linq.Expressions;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Core.Specification
{
	public class BaseSpecification<T> : ISpecification<T>
	{
		public List<string> Includes { get; set; } = new List<string>();
		public Expression<Func<T, bool>> Filter { get; private set; } = (T => true);
		public Expression<Func<T, object>> OrderBy { get; private set; }

		protected void AddFilter(Expression<Func<T, bool>> filter, bool condition = false)
		{
			if(condition)
				Filter = filter;
		}

		protected void AddIncludes(List<string> includes)
		{
			Includes.AddRange(includes);
		}

		public void AddOrderBy(string sortField)
		{
			if (!string.IsNullOrEmpty(sortField))
			{
				var propertyInfo = typeof(T).GetProperty(sortField);
				if (propertyInfo != null)
				{
					var orderByExp = Converter.CreateOrderByExpression<T>(sortField);
					OrderBy = orderByExp;
				}
				else
				{
					throw new FilterException("Wrong filter name.");
				}
			}
		}
	}
}
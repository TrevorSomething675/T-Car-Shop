using T_Car_Shop.Core.Exceptions.DomainExceptions;
using System.Linq.Expressions;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Core.Specification
{
	public class BaseSpecification<T> : ISpecification<T>// where T : BaseSpecification<T>, new()
	{
		public List<string> Includes { get; set; } = new List<string>();
		public Expression<Func<T, bool>> Query { get; private set; } = (T => true);
		public Expression<Func<T, object>> SortQuery { get; private set; }

		protected void AddFilter(Expression<Func<T, bool>> filter)
		{
			Query = filter;
		}

		protected void AddIncludes(List<string> includes)
		{
			Includes.AddRange(includes);
			//return (T)this;
		}

		public void AddOrderBy(string sortField)
		{
			if (!string.IsNullOrEmpty(sortField))
			{
				var propertyInfo = typeof(T).GetProperty(sortField);
				if (propertyInfo != null)
				{
					var orderByExp = Converter.CreateOrderByExpression<T>(sortField);
					SortQuery = orderByExp;
				}
				else
				{
					throw new FilterException("Wrong filter name.");
				}
			}
		}
	}
}

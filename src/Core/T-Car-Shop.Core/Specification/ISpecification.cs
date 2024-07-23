using System.Linq.Expressions;

namespace T_Car_Shop.Core.Specification
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Query { get; }
		List<Expression<Func<T, object>>> Includes { get; }
		Expression<Func<T, object>> OrderBy { get; }
		Expression<Func<T, object>> OrderByDescending { get; }
	}
}
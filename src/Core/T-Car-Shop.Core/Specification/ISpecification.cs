using System.Linq.Expressions;

namespace T_Car_Shop.Core.Specification
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Query { get; }
		List<string> Includes { get; }
	}
}
using System.Linq.Expressions;

namespace T_Car_Shop.Core.Shared
{
	public static class Converter
	{
		public static Expression<Func<T, object>> CreateOrderByExpression<T>(string propertyName)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, propertyName);
			var converted = Expression.Convert(property, typeof(object));
			return Expression.Lambda<Func<T, object>>(converted, parameter);
		}
		public static Expression<Func<T, bool>> CreateWhereExpression<T>(string query)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, query);
			var converted = Expression.Convert(property, typeof(bool));
			return Expression.Lambda<Func<T, bool>>(converted, parameter);
		}
	}
}
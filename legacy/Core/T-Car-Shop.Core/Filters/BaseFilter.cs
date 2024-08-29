using T_Car_Shop.Core.Models.DataAccess;

namespace T_Car_Shop.Core.Filters
{
	public class BaseFilter
	{
		public string SortField { get; set; } = nameof(BaseEntity.Id);
		public List<string> Includes { get; set; } = new List<string>();
	}
}
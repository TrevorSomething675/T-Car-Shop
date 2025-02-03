using T_Car_Shop.Domain.Models;

namespace T_Car_Shop.Domain.Filters
{
	public class BaseFilter
	{
		public string SortField { get; set; } = nameof(BaseModel.Id);
		public List<string> Includes { get; set; } = new List<string>();
	}
}
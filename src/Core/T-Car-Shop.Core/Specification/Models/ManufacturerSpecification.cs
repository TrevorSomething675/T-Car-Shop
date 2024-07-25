using T_Car_Shop.Core.Models.DataAccess;

namespace T_Car_Shop.Core.Specification.Models
{
	public class ManufacturerSpecification : BaseSpecification<ManufacturerEntity>
	{
		public ManufacturerSpecification Include(List<string> includes)
		{
			AddIncludes(includes);
			return this;
		}
	}
}
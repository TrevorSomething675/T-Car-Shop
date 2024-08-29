namespace T_Car_Shop.Domain.OptionModels
{
	public class DataBaseOptions
	{
		public const string SectionName = nameof(DataBaseOptions);
		public string ConnectionString { get; set; } = string.Empty;
	}
}
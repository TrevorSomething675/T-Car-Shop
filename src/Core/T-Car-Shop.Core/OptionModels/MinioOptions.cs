namespace T_Car_Shop.Core.OptionModels
{
	public class MinioOptions
	{
		public const string SectionName = "MinioOptions";
		public string ROOT_USER { get; set; }
		public string ROOT_PASSWORD { get; set; }
		public string StorageEndPoint { get; set; }
		public string DefaultImageBucketName { get; set; }
	}
}
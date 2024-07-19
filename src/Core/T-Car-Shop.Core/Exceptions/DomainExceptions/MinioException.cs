namespace T_Car_Shop.Core.Exceptions.DomainExceptions
{
	public class MinioException : Exception 
	{
		public MinioException(string message) : base(message) { }
	}
}
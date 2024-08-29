namespace T_Car_Shop.Core.Exceptions.DomainExceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string message) : base(message) { }
	}
}

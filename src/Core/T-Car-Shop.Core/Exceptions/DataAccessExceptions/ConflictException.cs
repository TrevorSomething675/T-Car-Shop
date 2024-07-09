namespace T_Car_Shop.Core.Exceptions.DataAccessExceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}
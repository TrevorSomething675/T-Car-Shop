using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;

namespace T_Car_Shop.Web.MIddlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch(NotFoundException ex)
			{
				await HandleNotFoundExceptionAsync(context, ex);
			}
		}
		private Task HandleNotFoundExceptionAsync(HttpContext context, Exception ex)
		{
			var result = new Result<BaseModel>
			{
				Value = null,
				ErrorMessages = new List<string>
				{
					ex.Message
				},
				StatusCode = StatusCodes.Status404NotFound
			};
			context.Response.StatusCode = StatusCodes.Status404NotFound;
			return context.Response.WriteAsJsonAsync(result);
		}
	}
}
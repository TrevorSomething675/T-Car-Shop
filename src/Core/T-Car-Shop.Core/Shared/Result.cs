using Microsoft.AspNetCore.Mvc;

namespace T_Car_Shop.Core.Shared
{
    public class Result<T> : IResult<T>
    {
        public T? Value { get; set; }
        public int StatusCode { get; set; } = 200;

        public IResult<T> Ok()
        {
            StatusCode = 200;
            return this;
        }

        public IResult<T> NotFound()
        {
            StatusCode = 404;
            return this;
        }

        public IResult<T> BadRequest()
        {
            StatusCode = 400;
            return this;
        }

        public ActionResult<IResult<T>> ToActionResult()
        {
            switch (StatusCode)
            {
                case 200:
                    return new OkObjectResult(this);
                case 404:
                    return new NotFoundObjectResult(this);
                case 400:
                    return new BadRequestObjectResult(this);
                default:
                    return new ObjectResult(this) { StatusCode = StatusCode };
            }
        }
    }
}
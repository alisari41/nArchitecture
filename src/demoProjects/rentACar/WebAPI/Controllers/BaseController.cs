using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        // Tamamen CQRS kullandığımız ve bunun içinde Mediator'ı kullandığımız için Mediator'a ihtiyaç olacak o yüzden BaseController yazıldı.
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


        #region JWT - Auth işlemleri
        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();
        }
        #endregion

    }
}

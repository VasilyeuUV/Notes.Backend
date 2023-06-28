using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class AControllerBase : ControllerBase
    {
        private IMediator _mediator;


        /// <summary>
        /// Для формирования команд при выполнении запросов
        /// </summary>
        protected IMediator Mediator 
            => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        /// <summary>
        /// Id Пользователя
        /// </summary>
        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}

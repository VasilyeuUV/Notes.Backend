using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Common.Behaviors
{
    /// <summary>
    /// Поведения валидаций 
    /// (для того, чтобы валидации работали, встроить объект этого класса в pipeline Медиатора)
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponce"></typeparam>
    internal class ValidationBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce>
        where TRequest : IRequest<TResponce>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;


        /// <summary>
        /// CTOR
        /// </summary>
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }


        //###########################################################################################################
        #region IPipelineBehavior<TRequest, TResponce>

        /// <summary>
        /// Обработка валидаций
        /// </summary>
        /// <param name="request">Объект запроса, переданный через метод IMediator.Send</param>
        /// <param name="cancellationToken"></param>
        /// <param name="next">Асинхронное продолжение для следующего действия в цепочке вызовов правил валидации</param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public Task<TResponce> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponce> next
            )
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            // - исключение при наличии валидаций
            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }

        #endregion // IPipelineBehavior<TRequest, TResponce>

    }
}

using FluentValidation;
using System;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    /// <summary>
    /// Правила валидации для получения списка Заметок
    /// </summary>
    internal class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public GetNoteListQueryValidator()
        {
            RuleFor(x => x.UserId)      // - набор правил валидации для Id пользователя
                .NotEqual(Guid.Empty);
        }
    }
}

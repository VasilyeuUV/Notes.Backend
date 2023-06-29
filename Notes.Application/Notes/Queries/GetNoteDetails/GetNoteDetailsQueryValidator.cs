using FluentValidation;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Правила валидации для получения деталей Заметки
    /// </summary>
    internal class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(note => note.Id)          // - набор правил валидации для Id Заметки
                .NotEqual(Guid.Empty);
            RuleFor(note => note.UserId)      // - набор правил валидации для Id пользователя
                .NotEqual(Guid.Empty);
        }
    }
}

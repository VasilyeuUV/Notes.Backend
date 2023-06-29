using FluentValidation;
using System;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    /// <summary>
    /// Правила валидации для измененияЗаметки
    /// </summary>
    internal class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public UpdateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Title)       // - набор правил валидации для Заголовка Заметки
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.UserId)      // - набор правил валидации для Id пользователя
                .NotEqual(Guid.Empty);
            RuleFor(createNoteCommand => createNoteCommand.Id)          // - набор правил валидации для Id Заметки
                .NotEqual(Guid.Empty);
        }
    }
}

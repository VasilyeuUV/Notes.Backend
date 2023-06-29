using FluentValidation;
using System;

namespace Notes.Application.Notes.Commands.CreateNotes
{
    /// <summary>
    /// Правила валидации для создания новой Заметки
    /// </summary>
    internal class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Title)       // - набор правил валидации для Заголовка Заметки
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.UserId)      // - набор правил валидации для Id пользователя
                .NotEqual(Guid.Empty);
        }
    }
}

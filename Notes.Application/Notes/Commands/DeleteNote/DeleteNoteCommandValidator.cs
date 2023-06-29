using FluentValidation;
using System;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    /// <summary>
    /// Правила валидации для удаления Заметки
    /// </summary>
    internal class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {

        /// <summary>
        /// CTOR
        /// </summary>
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id)          // - набор правил валидации для Id Заметки
                .NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand => deleteNoteCommand.UserId)      // - набор правил валидации для Id пользователя
                .NotEqual(Guid.Empty);
        }
    }
}

using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNotes
{
    /// <summary>
    /// Команда на создание Заметки
    /// (содержит только то, что необходимо для создания Заметки)
    /// </summary>
    internal class CreateNoteCommand : IRequest<Guid>
    {
        /// <summary>
        /// Id Пользователя, создавшего заметку
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Заголовок Заметки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Details { get; set; }
    }
}

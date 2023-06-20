using MediatR;
using System;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    /// <summary>
    /// Команда для обновления заметки
    /// </summary>
    public class UpdateNoteCommand : IRequest
    {
        /// <summary>
        /// Id Пользователя, создавшего заметку
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id заметки
        /// </summary>
        public Guid Id { get; set; }

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

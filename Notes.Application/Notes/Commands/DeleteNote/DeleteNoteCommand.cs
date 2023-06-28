using MediatR;
using System;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    /// <summary>
    /// Команда удаления Заметки
    /// </summary>
    public class DeleteNoteCommand : IRequest
    {
        /// <summary>
        /// Id Пользователя, создавшего заметку
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id заметки
        /// </summary>
        public Guid Id { get; set; }
    }
}

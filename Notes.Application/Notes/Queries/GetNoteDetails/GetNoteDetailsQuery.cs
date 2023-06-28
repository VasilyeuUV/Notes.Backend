using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Запрос на получение списка заметок
    /// </summary>
    public class GetNoteDetailsQuery : IRequest<NoteDetailsViewModel>
    {
        /// <summary>
        /// Id пользователя, добавившего заметку
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id заметки
        /// </summary>
        public Guid Id { get; set; }
    }
}

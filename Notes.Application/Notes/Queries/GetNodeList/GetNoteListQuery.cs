using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    /// <summary>
    /// Запрос на получение списка Заметок
    /// </summary>
    internal class GetNoteListQuery : IRequest<NoteListViewModel>
    {
        /// <summary>
        /// Id пользователя, добавившего заметку
        /// </summary>
        public Guid UserId { get; set; }
    }
}

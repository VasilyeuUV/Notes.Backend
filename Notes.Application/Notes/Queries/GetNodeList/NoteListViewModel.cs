using System.Collections.Generic;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    /// <summary>
    /// Вьюмодель списка Заметок
    /// </summary>
    internal class NoteListViewModel
    {
        /// <summary>
        /// Список Заметок
        /// </summary>
        public IList<NoteLookupDto> Notes { get; set; }
    }
}

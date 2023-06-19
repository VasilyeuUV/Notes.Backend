using System;

namespace Notes.Domain.Models
{
    /// <summary>
    /// Модель заметки
    /// </summary>
    public class NoteModel
    {

        /// <summary>
        /// Id пользователя, добавившего заметку
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id заметки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название заметки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Детали заметки
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Дата создания заметки
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата реадктирования заметки
        /// </summary>
        public DateTime? EditDate { get; set; }
    }
}

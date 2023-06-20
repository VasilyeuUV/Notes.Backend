using System;

namespace Notes.Application.Common.Exceptions
{
    /// <summary>
    /// Пользовательская ошибка "Не найден"
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }        
    }
}

using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    /// <summary>
    /// Контракт контекста данных для Заметок
    /// </summary>
    public interface INotesDbContext
    {

        /// <summary>
        /// Коллекция всех Заметок
        /// </summary>
        DbSet<NoteModel> Notes { get; set; }


        /// <summary>
        /// Сохранение изменений контекста в БД 
        /// (дублируем сигнатуру метода из класса DbContext фрэймворка для удобства)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

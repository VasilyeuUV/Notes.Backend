using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain.Models;
using Notes.Persistence.EntityTypeConfigurations;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="options"></param>
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {            
        }

        //##########################################################################################################################
        #region DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());       // - конфигурация сущности Заметки

            base.OnModelCreating(modelBuilder);
        }


        #endregion // DbContext


        //##########################################################################################################################
        #region INotesDbContext

        public DbSet<NoteModel> Notes { get; set; }


        #endregion // INotesDbContext
    }
}

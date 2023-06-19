using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Models;
using System;

namespace Notes.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Конфигурация для сохранения заметок в БД
    /// </summary>
    public class NoteConfiguration : IEntityTypeConfiguration<NoteModel>
    {


        //##########################################################################################################################
        #region IEntityTypeConfiguration<NoteModel>

        public void Configure(EntityTypeBuilder<NoteModel> builder)
        {
            builder.HasKey(note => note.Id);                        // - ключ
            builder.HasIndex(note =>note.Id).IsUnique();            // - ключ уникальный

            builder.Property(note => note.Title).HasMaxLength(250); // - максимальное количество символов для заголовка

        }

        #endregion // IEntityTypeConfiguration<NoteModel>
    }
}

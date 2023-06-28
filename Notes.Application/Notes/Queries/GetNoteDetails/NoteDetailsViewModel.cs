using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain.Models;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// То, что будет возвращаться Пользователю при запросе деталей Заметки
    /// </summary>
    public class NoteDetailsViewModel : IMapWith<NoteModel>
    {
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


        /// <summary>
        /// Создание соответсвий между этим классом и классом NoteModel
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteModel, NoteDetailsViewModel>()
                .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title, opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details, opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.CreationDate, opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate, opt => opt.MapFrom(note => note.EditDate));
        }
    }
}

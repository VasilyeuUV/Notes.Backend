using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain.Models;
using System;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    /// <summary>
    /// 
    /// </summary>
    public class NoteLookupDto : IMapWith<NoteModel>
    {

        /// <summary>
        /// Id заметки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название заметки
        /// </summary>
        public string Title { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteModel, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title));

        }
    }
}

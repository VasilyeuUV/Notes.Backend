using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;
using System;

namespace Notes.WebApi.Models
{
    public class UpdateNodeDto : IMapWith<UpdateNoteCommand>
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


        public void Mapping(Profile profile)
        {
            // - маппинг с командой изменения заметки
            profile.CreateMap<UpdateNodeDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id, opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}

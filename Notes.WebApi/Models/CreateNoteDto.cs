using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNotes;

namespace Notes.WebApi.Models
{
    /// <summary>
    /// Модель для заметки, приходящей с DTO
    /// </summary>
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {

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
            // - маппинг с командой создания заметки
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}

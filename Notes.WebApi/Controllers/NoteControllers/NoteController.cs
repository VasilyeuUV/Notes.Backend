using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNotes;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNodeList;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers.NoteControllers
{
    /// <summary>
    /// Контроллер для работы с Заметками
    /// </summary>
    public class NoteController : AControllerBase
    {
        private IMapper _mapper;            // - Маппер для преобразования входных данных в команду (внедряем tuj как зависимость через конструктор)


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="mapper"></param>
        public NoteController(IMapper mapper)
            => _mapper = mapper;



        /// <summary>
        /// Получение списка заметок
        /// </summary>
        /// <returns></returns>
        [HttpGet]                           // - тип запроса
        public async Task<ActionResult<NoteListViewModel>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Получение деталей Заметки по её Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsViewModel>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="createNoteDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Crate([FromBody] CreateNoteDto createNoteDto)
        {
            // - [FromBody] - параметр метода контроллера должен быть из данных тела http-запроса и затем десериализован с помощью форматора входных данных (json по умолчанию)

            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);        // - формируем команду
            command.UserId = UserId;                                            // - добавли к команде Id Пользователя

            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }


        /// <summary>
        /// Обновление (редактирование) заметки
        /// </summary>
        /// <param name="updateNoteDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNodeDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);        // - формируем команду
            command.UserId = UserId;                                            // - добавли к команде Id Пользователя

            await Mediator.Send(command);
            return NoContent();                                                 // - назад ничего не отправляем

        }


        /// <summary>
        /// Уладение заметки
        /// </summary>
        /// <param name="updateNoteDto"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNotes
{
    /// <summary>
    /// Обработчик создания команды
    /// (содержит логику создания Заметки)
    /// </summary>
    internal class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>      // - указываем тип запроса и тип ответа
    {
        private readonly INotesDbContext _dbContext;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="dbContext"></param>
        public CreateNoteCommandHandler(INotesDbContext dbContext)
            => _dbContext = dbContext;


        //##########################################################################################################################
        #region IRequestHandler<CreateNoteCommand, Guid> 

        /// <summary>
        /// Логика обработки команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new NoteModel
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }

        #endregion // IRequestHandler<CreateNoteCommand, Guid> 
    }
}

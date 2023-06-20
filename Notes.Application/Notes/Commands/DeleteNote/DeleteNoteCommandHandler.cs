using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    /// <summary>
    /// Обработчик команды удаления Заметки
    /// </summary>
    internal class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="dbContext"></param>
        public DeleteNoteCommandHandler(INotesDbContext dbContext)
            => _dbContext = dbContext;


        //##########################################################################################################################
        #region IRequestHandler<DeleteNoteCommand>

        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <param cref="Unit">Это тип, обозначающий пустой ответ (для MediatR 9.0)</param>
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            // - поиск
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null
                || entity.UserId != request.UserId
                )
                throw new NotFoundException(nameof(NoteModel), request.Id);

            // - удаление
            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Unit - Это тип, обозначающий пустой ответ(для MediatR 9.0)
            return Unit.Value;
        }

        #endregion // IRequestHandler<DeleteNoteCommand>

    }
}

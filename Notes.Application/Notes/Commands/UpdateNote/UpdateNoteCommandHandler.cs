using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    /// <summary>
    /// Обработчик команды обновления Заметки
    /// </summary>
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="dbContext"></param>
        public UpdateNoteCommandHandler(INotesDbContext dbContext)
            => _dbContext = dbContext;


        //##########################################################################################################################
        #region IRequestHandler<UpdateNoteCommand>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null
                || entity.UserId != request.UserId
                )
                throw new NotFoundException(nameof(NoteModel), request.Id);

            // - обновляем сущность
            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            // - сохраняем в контекст БД
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;          // - Unit - Это тип, обозначающий пустой ответ (для MediatR 9.0)
        }

        #endregion // IRequestHandler<UpdateNoteCommand>

    }
}

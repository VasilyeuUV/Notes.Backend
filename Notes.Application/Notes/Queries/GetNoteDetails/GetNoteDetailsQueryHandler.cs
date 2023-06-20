using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Обработчик Запроса на получение списка заметок
    /// </summary>
    internal class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsViewModel>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="dbContext"></param>
        public GetNoteDetailsQueryHandler(
            INotesDbContext dbContext,
            IMapper mapper
            )
            => (_dbContext, _mapper) = (dbContext, mapper);


        //##########################################################################################################################
        #region IRequestHandler<GetNoteDetailsQuery, NoteDetailsViewModel>

        public async Task<NoteDetailsViewModel> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                 .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null
                || entity.UserId != request.UserId
                )
                throw new NotFoundException(nameof(NoteModel), request.Id);

            return _mapper.Map<NoteDetailsViewModel>(entity);
        }

        #endregion // IRequestHandler<GetNoteDetailsQuery, NoteDetailsViewModel>
    }
}

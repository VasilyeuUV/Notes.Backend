using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNodeList
{
    /// <summary>
    /// Обработчик запроса на получение списка Заметок
    /// </summary>
    internal class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListViewModel>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(
            INotesDbContext dbContext,
            IMapper mapper
            )
            => (_dbContext, _mapper) = (dbContext, mapper);


        //##########################################################################################################################
        #region IRequestHandler<GetNoteListQuery, NoteListViewModel>

        public async Task<NoteListViewModel> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                 .Where(note => note.UserId == request.UserId)
                 .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)       // - проецирование коллекции в соответствии с заданной конфигурацией
                 .ToListAsync(cancellationToken);

            return new NoteListViewModel
            {
                Notes = notesQuery
            };
        }

        #endregion // IRequestHandler<GetNoteListQuery, NoteListViewModel>
    }
}

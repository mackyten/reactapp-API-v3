using Application.Contracts;
using Application.DTOs.NoteDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoteFeatures.Queries
{
    public class GetAllNoteListRequest 
    {

        INotesRepository _notesRepository;

        public GetAllNoteListRequest(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<List<Note>> Handle()
        {
            var notes =  await _notesRepository.GetAll();
            return notes;
        }
    }
}

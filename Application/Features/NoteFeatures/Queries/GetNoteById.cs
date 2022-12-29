using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoteFeatures.Queries
{
    public class GetNoteById
    {
        INotesRepository _notesRepository;

        public GetNoteById(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }


        public async Task<Note> Handle(int id)
        {
            var notes = await _notesRepository.GetById(id);
            return notes;
        }
    }
}

using Application.Contracts;
using Application.DTOs.NoteDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoteFeatures.Commands
{
    public class CreateNote
    {
        INotesRepository _notesRepository;

        public CreateNote(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<bool> CreateNewNote(NewNoteDTO newNote) { 
             var result = await _notesRepository.CreateNote(newNote);
            return result;

        }
    }
}

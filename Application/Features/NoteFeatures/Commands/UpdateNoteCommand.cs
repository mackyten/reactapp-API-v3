using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoteFeatures.Commands
{
    public class UpdateNoteCommand
    {
        INotesRepository _notesRepository;

        public UpdateNoteCommand(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<bool> UpdateNote(Note note)
        {
            var result = await _notesRepository.UpdateNote(note);
            return result;

        }
    }
}

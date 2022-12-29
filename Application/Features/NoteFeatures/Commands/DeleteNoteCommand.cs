using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoteFeatures.Commands
{
    public class DeleteNoteCommand
    {

        INotesRepository _notesRepository;

        public DeleteNoteCommand(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<bool> DeleteNote(Note note)
        {
            var result = await _notesRepository.DeleteNote(note);
            return result;

        }
    }
}

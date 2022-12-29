using Application.DTOs.NoteDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface INotesRepository 
    {
        public Task<List<Note>> GetAll();
        public Task<Note> GetById(int id);

        public Task<bool> CreateNote(NewNoteDTO newNote);
        public Task<bool> UpdateNote(Note note);

        public Task<bool> DeleteNote(Note note);

    }
}

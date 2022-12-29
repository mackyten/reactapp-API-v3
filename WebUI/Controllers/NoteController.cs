using Application.Contracts;
using Application.DTOs.NoteDTO;
using Application.Features.NoteFeatures.Commands;
using Application.Features.NoteFeatures.Queries;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        GetAllNoteListRequest _allNoteListRequest;
        GetNoteById _getNoteById;
        CreateNote _createNote;
        UpdateNoteCommand _updateNoteCommand;
        DeleteNoteCommand _deleteNoteCommand;

        public NoteController(
            GetAllNoteListRequest allNoteListRequest,
            GetNoteById getNoteById,
            CreateNote createNote,
            UpdateNoteCommand updateNoteCommand,
            DeleteNoteCommand deleteNoteCommand
            )
        {
            _allNoteListRequest = allNoteListRequest;
            _getNoteById = getNoteById;
            _createNote = createNote;
            _updateNoteCommand = updateNoteCommand;
            _deleteNoteCommand = deleteNoteCommand;

        }


        // GET: api/<NoteController>
        [HttpGet("GetAllNotes")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var notes = await _allNoteListRequest.Handle();
            return Ok(notes);

        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetbyId(int id)
        {
            var note = await _getNoteById.Handle(id);
            return Ok(note);
        }

        // POST api/<NoteController>
        [HttpPost("CreateNewNote")]
        [Authorize]
        public async Task<IActionResult> PostNote([FromBody] NewNoteDTO newNote)
        {
            var result = await _createNote.CreateNewNote(newNote);
            return Ok(result);
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            var noteToUpdate = await _getNoteById.Handle(id);
            var result = await _updateNoteCommand.UpdateNote(note);
            if (result)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
            

        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var noteToDelete = await _getNoteById.Handle(id);
            var result = await _deleteNoteCommand.DeleteNote(noteToDelete);
            return Ok(result);

        }
    }
}

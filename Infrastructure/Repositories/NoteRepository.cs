using Application.Contracts;
using Application.DTOs.NoteDTO;
using Application.Features.NoteFeatures.Queries;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NoteRepository : INotesRepository 
    {


        public async Task<List<Note>> GetAll()
        {
            using (var db = new AppDbContext())
            {
                return await db.Notes.ToListAsync();
            }
        }

        public async Task<Note> GetById(int id)
        {
            using (var db = new AppDbContext())
            {
                return await db.Notes.FirstOrDefaultAsync(note => note.Id == id);
            }
        }

        public async Task<bool> CreateNote(Note note)
        {
            using (var db = new AppDbContext()) {
                try
                {
                    await db.Notes.AddAsync(note);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateNote(Note note)
        {
            using (var db = new AppDbContext())
            {

                try
                {
                    db.Notes.Update(note);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public async Task<bool> DeleteNote(Note note)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Remove(note);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception) {

                    return false;
                }

                

            }
        }
    }
}

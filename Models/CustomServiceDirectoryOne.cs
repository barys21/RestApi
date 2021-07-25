using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Models
{
    public class CustomServiceDirectoryOne
    {
        public async Task<IEnumerable<DirectoryOne>> GetDirectoryOnes(ApplicationDbContext context)
        {
            return await context.DirectoryOnes.ToListAsync();
        }

        public async Task<DirectoryOne> GetDirectoryOneId(ApplicationDbContext context, int id)
        {
            var directoryOne = await context.DirectoryOnes.FindAsync(id);
            return directoryOne;
        }

        public async Task PutDirectoryOne(ApplicationDbContext context, DirectoryOne directoryOne)
        {
            context.Entry(directoryOne).State = EntityState.Modified;
            var original = await context.DirectoryOnes.FirstOrDefaultAsync(s => s.Id == directoryOne.Id);
            original.Name = directoryOne.Name;
            try
            {
                context.Update(original);
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }

        public async Task PostDirectoryOne(ApplicationDbContext context, DirectoryOne directoryOne)
        {
            context.DirectoryOnes.Add(directoryOne);
            await context.SaveChangesAsync();
            //return CreatedAtAction("GetDirectoryOne", new { id = directoryOne.Id }, directoryOne);
        }

        public async Task<DirectoryOne> DeleteDirectoryOne(ApplicationDbContext context, int id)
        {
            var directoryOne = await context.DirectoryOnes.FindAsync(id);
            context.DirectoryOnes.Remove(directoryOne);
            await context.SaveChangesAsync();
            return directoryOne;
        }
    }
}

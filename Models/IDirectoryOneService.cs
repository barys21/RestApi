using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public interface IDirectoryOneService
    {
        Task<IEnumerable<DirectoryOne>> GetDirectoryOnes(ApplicationDbContext context);
        Task<DirectoryOne> GetDirectoryOneId(ApplicationDbContext context, int id);
        Task PutDirectoryOne(ApplicationDbContext context, int id, DirectoryOne directoryOne);
        Task PostDirectoryOne(ApplicationDbContext context, DirectoryOne directoryOne);
        Task<DirectoryOne> DeleteDirectoryOne(ApplicationDbContext context, int id);
    }
}

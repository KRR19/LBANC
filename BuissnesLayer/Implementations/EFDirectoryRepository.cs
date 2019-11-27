using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entitys;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BuissnesLayer.Implementations
{
    public class EFDirectoryRepository : IDirectoryRepository
    {
        private readonly EFDBContext _context;
        public EFDirectoryRepository(EFDBContext context)
        {
            _context = context;
        }
        public void DeleteDirectory(Directory directory)
        {
            _context.Directories.Remove(directory);
            _context.SaveChanges();
        }

        public IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false)
        {
            if(includeMaterials)
            {
                return _context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            }
            else
            {
                return _context.Directories.ToList();
            }

        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if(includeMaterials)
            {
                return _context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            }
            else
            {
                return _context.Directories.FirstOrDefault(x => x.Id == directoryId);
            }
        }

        public void SaveDirectory(Directory directory)
        {
            if(directory.Id == 0)
            {
                _context.Directories.Add(directory);
            }
            else
            {
                _context.Entry(directory).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}

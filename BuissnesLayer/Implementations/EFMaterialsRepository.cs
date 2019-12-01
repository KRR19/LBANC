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
    public class EFMaterialsRepository : IMaterialRepository
    {
        private readonly EFDBContext _context;
        public EFMaterialsRepository(EFDBContext context)
        {
            _context = context;
        }
        public void DeleteDirectory(Material material)
        {
            _context.Materials.Remove(material);
            _context.SaveChanges();
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if(includeDirectory)
            {
                return _context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            }
            else
            {
                return _context.Materials.ToList();
            }
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if(includeDirectory)
            {
                return _context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            }
            else
            {
                return _context.Materials.FirstOrDefault(x => x.Id == materialId);
            }
        }

        public void SaveMaterial(Material material)
        {
            if(material.Id == 0 )
            {
                _context.Materials.Add(material);
            }
            else
            {
                _context.Entry(material).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}

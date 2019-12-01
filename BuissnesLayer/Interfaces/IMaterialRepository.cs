using DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
        Material GetMaterialById(int directoryId, bool includeDirectory = false);
        void SaveMaterial(Material material);
        void DeleteDirectory(Material material);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Directories.Any())
            {
                context.Directories.Add(new Entitys.Directory() { Title = "First Directory", Html = "<b>Directory Content</b>" });
                context.Directories.Add(new Entitys.Directory() { Title = "Second Directory", Html = "<b>Directory Content</b>" });
                context.SaveChanges();

                context.Materials.Add(new Entitys.Material() { Title = "First Material", Html = "<i>Material Content</i>", DirectoryId = context.Directories.First().Id });
                context.Materials.Add(new Entitys.Material() { Title = "Second Material", Html = "<i>Material Content</i>", DirectoryId = context.Directories.First().Id });
                context.Materials.Add(new Entitys.Material() { Title = "Third Material", Html = "<i>Material Content</i>", DirectoryId = context.Directories.ToList().Last().Id });
                context.SaveChanges();
            }
        }
    }
}

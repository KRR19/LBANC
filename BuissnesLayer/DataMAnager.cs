using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataMAnager
    {
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IMaterialRepository _materialRepository;

        public DataMAnager(IDirectoryRepository directoryRepository, IMaterialRepository materialRepository)
        {
            _directoryRepository = directoryRepository;
            _materialRepository = materialRepository;
        }
        public IDirectoryRepository Directorys { get { return _directoryRepository; } }
        public IMaterialRepository Materials { get { return _materialRepository; } }
    }
}

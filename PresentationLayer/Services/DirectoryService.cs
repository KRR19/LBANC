using BuissnesLayer;
using DataLayer.Entitys;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    class DirectoryService
    {
        private readonly DataManager _dataManager;
        private readonly MaterialService _materialService;
        public DirectoryService(DataManager dataManager)
        {
            this._dataManager = dataManager;
            this._materialService = new MaterialService(dataManager);
        }

        public List<DirectoryViewModel> GetDirectoryList()
        {
            IEnumerable<Directory> _dirs = _dataManager.Directorys.GetAllDirectories();

            List<DirectoryViewModel> _modelList = new List<DirectoryViewModel>();
            foreach(var Item in _dirs)
            {
                _modelList.Add(DirectoryDBToViewModelById(Item.Id));
            }
            return _modelList;
        }

        private DirectoryViewModel DirectoryDBToViewModelById(int directoryId)
        {
            Directory _directory = _dataManager.Directorys.GetDirectoryById(directoryId, true);

            List<MaterialViewModel> _materiaslViewModelList = new List<MaterialViewModel>();
            foreach(var item in _directory.Materials)
            {
                _materiaslViewModelList.Add(_materialService.MaterialDBModelToView(item.Id));
            }
            return new DirectoryViewModel() { Directory = _directory, Materials = _materiaslViewModelList };
        }
        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _directoryDbModel;
            if(directoryEditModel.Id!=0)
            {
                _directoryDbModel = _dataManager.Directorys.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                _directoryDbModel = new Directory();
            }
            _directoryDbModel.Title = directoryEditModel.Title;
            _directoryDbModel.Html = directoryEditModel.Html;
            
            _dataManager.Directorys.SaveDirectory(_directoryDbModel);

            return DirectoryDBToViewModelById(_directoryDbModel.Id);
        }

        public DirectoryEditModel CreateNewDirectoryEditModel()
        {
            return new DirectoryEditModel() { };
        }
    }
}

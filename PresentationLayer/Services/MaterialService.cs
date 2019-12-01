using BuissnesLayer;
using DataLayer.Entitys;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private readonly DataManager _dataManager;
        public MaterialService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public MaterialViewModel MaterialDBModelToView(int materialId)
        {
            MaterialViewModel _model = new MaterialViewModel()
            {
                Material = _dataManager.Materials.GetMaterialById(materialId, true)
            };
            Directory _dir = _dataManager.Directorys.GetDirectoryById(_model.Material.DirectoryId, true);

            if(_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) != _dir.Materials.Count()-1)
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) + 1);
            }
            return _model;
        }

        public MaterialEditModel GetMaterialEditModel(int materialId)
        {
            Material _dbModel = _dataManager.Materials.GetMaterialById(materialId);
            var _editModel = new MaterialEditModel()
            {
                Id = _dbModel.Id,
                DirectoryId = _dbModel.DirectoryId,
                Title = _dbModel.Title,
                Html = _dbModel.Html
            };
            return _editModel;
        }

        public MaterialViewModel SaveMaterialEditModelToDb(MaterialEditModel editModel)
        {
            Material material;
            if(editModel.Id != 0)
            {
                material = _dataManager.Materials.GetMaterialById(editModel.Id);
            }
            else
            {
                material = new Material();
            }
            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryId = editModel.DirectoryId;
            _dataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
        }
        public MaterialEditModel CreateNewMaterialEditModel(int directoryId)
        {
            return new MaterialEditModel() { DirectoryId = directoryId };
        }
    }
}

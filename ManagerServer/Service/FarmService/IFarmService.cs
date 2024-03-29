﻿using Common.Model.Farm;
using ManagerServer.Database.Entity;
using ManagerServer.Model;
using ManagerServer.Model.Farm;
using ManagerServer.Model.ResponeModel;

namespace ManagerServer.Service.FarmService
{
    public interface IFarmService
    {
        Task<List<FarmEntity>> GetAll();
        Task<ResponseModel<bool>> AddFarm(FarmQueryModel query, string token);
        Task<bool> UpdateFarm(FarmUpdateModel query, string token);
        Task<FarmEntity> GetById(int Id);
        Task<ResponseModel<List<FarmEntity>>> GetByOwnerId(string token, BaseQueryModel baseQueryModel);
    }
}

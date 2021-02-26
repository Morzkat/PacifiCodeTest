using KHahn.ApplicationProcess.February2021.Domain.Models.Common;
using KHahn.ApplicationProcess.February2021.Domain.Models.DTOs;
using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Interfaces.Managers
{
    public interface IAssetsManager
    {
        Task<Result<ResponseWithList<AssetDTO>>> GetAllAssets();
        Task<Result<ResponseWithElement<AssetDTO>>> GetAsset(int AssetId);
        Task<Result<ResponseWithElement<string>>> NewAsset(AssetDTO asset);
        Task<Result<ResponseWithElement<bool>>> UpdateAsset(AssetDTO asset);
        Task<Result<ResponseWithElement<bool>>> DeleteAsset(int assetId);
    }
}
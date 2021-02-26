using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Managers;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.UnitOfWork;
using KHahn.ApplicationProcess.February2021.Domain.Models.Common;
using KHahn.ApplicationProcess.February2021.Domain.Models.DTOs;
using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using KHahn.ApplicationProcess.February2021.Domain.Helpers;
using System;
using KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.KHanMapper;
using Microsoft.Extensions.Logging;

namespace KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.Managers
{
    public class AssetsManager : IAssetsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKHanMapper _khanMapper;
        private readonly ILogger<AssetsManager> _logger;

        public AssetsManager(IUnitOfWork unitOfWork, IKHanMapper khanMapper, ILogger<AssetsManager> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _khanMapper = khanMapper;
        }

        public async Task<Result<ResponseWithList<AssetDTO>>> GetAllAssets()
        {
            var errors = new Dictionary<string, List<string>>();
            _logger.LogInformation("Getting all assets");

            try
            {
                var assets = _khanMapper.MapToANew<IEnumerable<Asset>, IEnumerable<AssetDTO>>(await _unitOfWork.AssetsRepository.GetAllAsync());
                return ResponseHelper.NewResult(HttpStatusCode.OK, ResponseHelper.NewResponseWithList(assets, "List of assets"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all assets | error: {ex.Message}");
                errors.Add("$.assets", new List<string> { ex.Message });
                return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithList<AssetDTO>(null, "List of assets", errors));
            }
        }

        public async Task<Result<ResponseWithElement<AssetDTO>>> GetAsset(int assetId)
        {
            var errors = new Dictionary<string, List<string>>();
            _logger.LogInformation($"Error getting assets with id: {assetId}");

            try
            {
                var exist = await _unitOfWork.AssetsRepository.ExistAsync(r => r.Id == assetId);

                if (!exist)
                {
                    errors.Add("$.asset", new List<string> { "The asset doesn't exist." });
                    return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<AssetDTO>(errors: errors));
                }

                var asset = _khanMapper.MapToANew<Asset, AssetDTO>(await _unitOfWork.AssetsRepository.GetByIdAsync(assetId));
                return ResponseHelper.NewResult(HttpStatusCode.OK, ResponseHelper.NewResponseWithElement(asset, "List of assets"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting assets with id: {assetId} | error: {ex.Message}");
                errors.Add("$.asset", new List<string> { ex.Message });
                return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<AssetDTO>(null, "Asset", errors));
            }
        }

        public async Task<Result<ResponseWithElement<string>>> NewAsset(AssetDTO asset)
        {
            var errors = new Dictionary<string, List<string>>();

            try
            {
                var exist = await _unitOfWork.AssetsRepository.ExistAsync(r => r.Id == asset.ID);

                if (exist)
                {
                    _logger.LogError($"Error adding new asset | error: A asset with that id exist.");
                    errors.Add("$.asset", new List<string> { "A asset with that id exist." });
                    return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<string>(errors: errors));

                }

                var newAsset = _khanMapper.MapToANew<AssetDTO, Asset>(asset);

                await _unitOfWork.AssetsRepository.AddAsync(newAsset);
                await _unitOfWork.SaveAsync();

                //Logger.
                return ResponseHelper.NewResult(HttpStatusCode.OK, ResponseHelper.NewResponseWithElement($"Assets/{newAsset.Id}"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding new asset | error: {ex.Message}");
                errors.Add("$.asset", new List<string> { ex.Message });
                return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<string>(null, "Add new asset", errors));
            }
        }

        public async Task<Result<ResponseWithElement<bool>>> UpdateAsset(AssetDTO asset)
        {
            var errors = new Dictionary<string, List<string>>();
            try
            {

                var exist = await _unitOfWork.AssetsRepository.ExistAsync(r => r.Id == asset.ID);

                if (!exist)
                {
                    _logger.LogError($"Error updating asset with id: {asset.ID}| error: A asset with that id doesn't exist.");
                    errors.Add("$.asset", new List<string> { "The asset doesn't exist." });
                    return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<bool>(errors: errors));

                }

                var assetToUpdate = _khanMapper.MapToANew<AssetDTO, Asset>(asset);

                await _unitOfWork.AssetsRepository.UpdateAsync(assetToUpdate);
                return ResponseHelper.NewResult(HttpStatusCode.OK, ResponseHelper.NewResponseWithElement(true));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating asset with id: {asset.ID}| error: {ex.Message}");
                errors.Add("$.asset", new List<string> { ex.Message });
                return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<bool>(false, "Update asset", errors));
            }
        }

        public async Task<Result<ResponseWithElement<bool>>> DeleteAsset(int assetId)
        {
            var errors = new Dictionary<string, List<string>>();

            try
            {
                var exist = await _unitOfWork.AssetsRepository.ExistAsync(r => r.Id == assetId);

                if (!exist)
                {
                    _logger.LogError($"Error deleting asset with id: {assetId}| error: A asset with that id doesn't exist.");
                    errors.Add("$.asset", new List<string> { "The asset doesn't exist." });
                    return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<bool>(errors: errors));

                }

                var asset = await _unitOfWork.AssetsRepository.GetByIdAsync(assetId);
                await _unitOfWork.AssetsRepository.DeleteAsync(asset);
                return ResponseHelper.NewResult(HttpStatusCode.OK, ResponseHelper.NewResponseWithElement(true));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting asset with id: {assetId}| error: {ex.Message}");
                errors.Add("$.asset", new List<string> { ex.Message });
                return ResponseHelper.NewResult(HttpStatusCode.BadRequest, ResponseHelper.NewResponseWithElement<bool>(false, "Update asset", errors));
            }
        }
    }
}
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Managers;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.UnitOfWork;
using KHahn.ApplicationProcess.February2021.Domain.Models.Common;
using KHahn.ApplicationProcess.February2021.Domain.Models.DTOs;
using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsManager _assetsManager;

        public AssetsController(IAssetsManager assetsManager)
        {
            _assetsManager = assetsManager;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseWithList<AssetDTO>>> GetAllAssets()
        {
            var result = await _assetsManager.GetAllAssets();
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        [HttpGet("{assetId}")]
        public async Task<ActionResult<ResponseWithElement<AssetDTO>>> GetAsset(int assetId)
        {
            var result = await _assetsManager.GetAsset(assetId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseWithElement<string>>> NewAsset(AssetDTO asset)
        {
            var result = await _assetsManager.NewAsset(asset);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseWithElement<bool>>> UpdateAsset(AssetDTO asset)
        {
            var result = await _assetsManager.UpdateAsset(asset);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        [HttpDelete("{assetId}")]
        public async Task<ActionResult<ResponseWithElement<bool>>> Delete(int assetId)
        {
            var result = await _assetsManager.DeleteAsset(assetId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }
    }
}

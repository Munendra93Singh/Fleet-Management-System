using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMRepository;
using FleetManagementRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssingController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public AssingController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("GetAssingTruckByTruckId")]
        [HttpPost]
        public ApiResult<TruckDriverDetails> GetAssingTruckByTruckId(TruckDriverDetails truckDriverDetails)
        {
            ApiResult<TruckDriverDetails> result = new ApiResult<TruckDriverDetails> { ResponseStatus = false };
            try
            {
                TruckDetails truckDetailsexist = _repoWrapper.TruckDetails.FindByCondition(x => x.Id == truckDriverDetails.TruckDetailsId).FirstOrDefault();
                if (truckDetailsexist != null && truckDetailsexist.Id > 0)
                {
                    result.ResponseStatus = true;
                    truckDriverDetails = _repoWrapper.TruckDriverDetails.FindByCondition(x => x.TruckDetailsId == truckDetailsexist.Id).FirstOrDefault();
                    truckDriverDetails.TruckDetails = truckDetailsexist;
                    result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                    if (truckDriverDetails != null && truckDriverDetails.Id > 0)
                    {
                        truckDriverDetails.DriverDetails = _repoWrapper.DriverDetails.FindByCondition(x => x.Id == truckDriverDetails.DriverDetailsId).FirstOrDefault();
                        result.Message = "Data Send Successfully !!";
                    }
                    else
                    {
                        result.Message = "This Truck Not Assing To Any Driver";
                    }
                    result.data = truckDriverDetails;
                }
                else
                {
                    result.StatusCode = FleetManagementRepository.Models.StatusCode.BadRequest.GetHashCode();
                    result.Message = "Data Not Found.";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("AssingTruckDriver")]
        [HttpPost]
        public ApiResult<TruckDriverDetails> AssingTruckDriver(TruckDriverDetails truckDriverDetails)
        {
            ApiResult<TruckDriverDetails> result = new ApiResult<TruckDriverDetails> { ResponseStatus = false };
            try
            {
                truckDriverDetails.IsActive = true;
                truckDriverDetails.CreatedBy = 1;
                truckDriverDetails.CreatedDate = DateTime.Now;
                result.data = _repoWrapper.TruckDriverDetails.Create(truckDriverDetails);
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Save Successfully !!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }

}

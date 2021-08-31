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
    public class TruckDetailsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public TruckDetailsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [Route("GetTruckDetailById")]
        [HttpPost]
        public ApiResult<TruckDetails> GetTruckDetailById(TruckDetails truckDetails)
        {
            ApiResult<TruckDetails> result = new ApiResult<TruckDetails> { ResponseStatus = false };
            try
            {
                TruckDetails truckDetailsexist = _repoWrapper.TruckDetails.FindByCondition(x => x.Id == truckDetails.Id).FirstOrDefault();

                if (truckDetailsexist != null && truckDetailsexist.Id > 0)
                {
                    truckDetailsexist.TruckCompartment = _repoWrapper.TruckCompartment.FindByCondition(x => x.TruckDetailsId == truckDetailsexist.Id);
                    result.data = truckDetailsexist;
                    result.ResponseStatus = true;
                    result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                    result.Message = "Data Send Successfully !!";
                }
                else
                {
                    result.StatusCode = FleetManagementRepository.Models.StatusCode.BadRequest.GetHashCode();
                    result.Message = "Data Not Found.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [Route("AddTruckDetail")]
        [HttpPost]
        public ApiResult<TruckDetails> AddTruckDetail(TruckDetails truckDetails)
        {
            ApiResult<TruckDetails> result = new ApiResult<TruckDetails> { ResponseStatus = false };
            try
            {
                truckDetails.IsActive = true;
                truckDetails.CreatedBy = 1;
                truckDetails.CreatedDate = DateTime.Now;
                if (truckDetails.TruckCompartment != null)
                {
                    var compartment = truckDetails.TruckCompartment.ToList();
                    compartment.ForEach(x => x.IsActive = true);
                    compartment.ForEach(x => x.CreatedBy = 1);
                    compartment.ForEach(x => x.CreatedDate = DateTime.Now);
                    truckDetails.TruckCompartment = compartment;
                }
                result.data = _repoWrapper.TruckDetails.Create(truckDetails);
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

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
    public class ParentBranchController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public ParentBranchController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("GetParentBranch")]
        [HttpGet]
        public ApiResult<IEnumerable<ParentBranch>> GetParentBranch()
        {
            ApiResult<IEnumerable<ParentBranch>> result = new ApiResult<IEnumerable<ParentBranch>> { ResponseStatus = false };
            try
            {
                result.data = _repoWrapper.ParentBranch.FindAll();
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Send Successfully !!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("GetParentBranchById")]
        [HttpPost]
        public ApiResult<ParentBranch> GetParentBranchById(ParentBranch parentBranch)
        {
            ApiResult<ParentBranch> result = new ApiResult<ParentBranch> { ResponseStatus = false };
            try
            {
                ParentBranch parentBranchexist = _repoWrapper.ParentBranch.FindByCondition(x => x.Id == parentBranch.Id).FirstOrDefault();

                if (parentBranchexist != null && parentBranchexist.Id > 0)
                {
                    parentBranchexist.TruckType = _repoWrapper.TruckType.FindByCondition(x => x.ParentBranchId == parentBranchexist.Id);
                    result.data = parentBranchexist;
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
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("AddParentBranch")]
        [HttpPost]
        public ApiResult<ParentBranch> AddParentBranch(ParentBranch parentBranch)
        {
            ApiResult<ParentBranch> result = new ApiResult<ParentBranch> { ResponseStatus = false };
            try
            {
                parentBranch.IsActive = true;
                parentBranch.CreatedBy = 1;
                parentBranch.CreatedDate = DateTime.Now;
                if (parentBranch.TruckType != null)
                {
                    var truckType = parentBranch.TruckType.ToList();
                    truckType.ForEach(x => x.IsActive = true);
                    parentBranch.TruckType = truckType;
                }
                result.data = _repoWrapper.ParentBranch.Create(parentBranch);
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

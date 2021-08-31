using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMRepository;
using CRMRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRMRepository.IRepository;
using CRMRepository.Repository;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManagementRepository.Models;
using System.IO;
using System.Drawing;

namespace FleetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public DriverController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("GetDriver")]
        [HttpGet]
        public ApiResult<IEnumerable<ApiDriver>> GetDriver()
        {
            ApiResult<IEnumerable<ApiDriver>> result = new ApiResult<IEnumerable<ApiDriver>> { ResponseStatus = false };
            try
            {
                result.data = _repoWrapper.ApiDriver.FindAll();
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


        [Route("GetDriverById")]
        [HttpGet]
        public ApiResult<ApiDriver> GetDriverById(Guid Id)
        {
            ApiResult<ApiDriver> result = new ApiResult<ApiDriver> { ResponseStatus = false };
            try
            {
                result.data = _repoWrapper.ApiDriver.FindByCondition(x => x._Id == Id).FirstOrDefault();
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



        [Route("AddDriver")]
        [HttpPost]
        public ApiResult<ApiDriver> AddDriver(ApiDriver apiDrivers)
        {
            ApiResult<ApiDriver> result = new ApiResult<ApiDriver> { ResponseStatus = false };
            try
            {
                apiDrivers.IsActive = true;
                apiDrivers.CreatedBy = 1;
                apiDrivers.CreatedDate = DateTime.Now;
                result.data = _repoWrapper.ApiDriver.Create(apiDrivers);
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

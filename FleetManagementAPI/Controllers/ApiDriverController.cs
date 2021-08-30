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
    public class ApiDriverController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public ApiDriverController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("GetApiDriver")]
        [HttpGet]
        public ApiResult<IEnumerable<ApiDriver>> GetApiDriver()
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


        [Route("GetDriverApi/{Id}")]
        [HttpGet]
        public ApiResult<ApiDriver> GetDriverApi(Guid Id)
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



        [Route("AddApiDriver")]
        [HttpPost]
        public ApiResult<ApiDriver> AddApiDriver(ApiDriver apiDrivers)
        {
            ApiResult<ApiDriver> result = new ApiResult<ApiDriver> { ResponseStatus = false };
            try
            {
                //if (apiDrivers.ImageUrl != null)
                //{
                //    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(apiDrivers.ImageUrl)))
                //    {
                //        using (Bitmap bm2 = new Bitmap(ms))
                //        {
                //            bm2.Save("SavingPath" + "ImageName.jpg");
                //        }
                //    }
                //}
                apiDrivers.IsActive = true;
                result.data = _repoWrapper.ApiDriver.Create(apiDrivers);
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Save Successfully !!";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}

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
        [Route("GetDriverApi/{Id}")]
        [HttpGet]
        public ApiDriver GetDriverApi(Guid Id)
        {

            ApiDriver apiDrivers = _repoWrapper.ApiDriver.FindByCondition(x => x._Id == Id).FirstOrDefault();
           // apiDrivers.ApiDriverRequestField = _repoWrapper.ApiDriverRequestField.FindByCondition(x => x.ApiMasterId == apiDrivers.Id);
           // apiDrivers.ApiTypDriver = _repoWrapper.ApiTypeDriver.FindByCondition(x => x.Id == apiDrivers.ApiTypeMasterId).FirstOrDefault();

            //apiDrivers.ApiRequestDriver = _repoWrapper.ApiRequestDriver.FindByCondition(x => x.Id == apiDrivers.ApiRequestDriverId).FirstOrDefault();

            return apiDrivers;
        }

        [Route("GetDriverApiByID/{Id}")]
        [HttpGet]
        public ApiDriver GetDriverApiByID(Guid Id)
        {
            ApiDriver apiDrivers = _repoWrapper.ApiDriver.FindByCondition(x => x._Id == Id).FirstOrDefault();
           // apiDrivers.Body = _repoWrapper.ApiDriverRequestField.FindByCondition(x => x.ApiDriverId == apiDrivers.Id).ToDictionary(dict => dict.key, dict => dict.Value);

            return apiDrivers;
        }
        [Route("GetApiDriver")]
        [HttpGet]
        public IEnumerable<ApiDriver> GetApiDrivers()
        {
            IEnumerable<ApiDriver> apiDrivers = _repoWrapper.ApiDriver.FindAll();
            return apiDrivers;
        }
        [Route("AddApiDriver")]
        [HttpPost]
        public ApiDriver AddApiDriver(ApiDriver apiDrivers)
        {
            apiDrivers = _repoWrapper.ApiDriver.Create(apiDrivers);
            return apiDrivers;
        }

    }
}

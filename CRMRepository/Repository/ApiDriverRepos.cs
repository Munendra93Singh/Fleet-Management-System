using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using CRMRepository.Models;

namespace CRMRepository.Repository
{
  public  class ApiDriverRepos :RepositoryBase<ApiDriver>, IApiDriverRepos
    {
        public ApiDriverRepos(CRMContext cRMContext):base(cRMContext)
        {

        }
    }
}

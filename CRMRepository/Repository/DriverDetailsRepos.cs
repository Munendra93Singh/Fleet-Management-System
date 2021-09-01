using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using CRMRepository.Models;

namespace CRMRepository.Repository
{
  public  class DriverDetailsRepos :RepositoryBase<DriverDetails>, IDriverDetailsRepos
    {
        public DriverDetailsRepos(CRMContext cRMContext):base(cRMContext)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Repository;

namespace CRMRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CRMContext _cRMContext;
        private IApiDriverRepos _apiDriver;
        private IParentBranchRepos _ParentBranch;
        public IApiDriverRepos ApiDriver
        {
            get
            {
                if (_apiDriver == null)
                {
                    _apiDriver = new ApiDriverRepos(_cRMContext);
                    
                }
                return _apiDriver;
            }
        }

        public IParentBranchRepos ParentBranch
        {
            get
            {
                if (_ParentBranch == null)
                {
                    _ParentBranch = new ParentBranchRepos(_cRMContext);

                }
                return _ParentBranch;
            }
        }

        public RepositoryWrapper(CRMContext cRMContext)
        {
            _cRMContext = cRMContext;
        }
        public void Save()
        {
            _cRMContext.SaveChanges();
        }

    }
}
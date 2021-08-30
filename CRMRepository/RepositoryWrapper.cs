using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using CRMRepository.Repository;


namespace CRMRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CRMContext _cRMContext;
        private ApiDriverRepos _apiDriver;
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
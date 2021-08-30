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
        //private IApiTypeDriverRepos _apiTypeDriver;
        //private readonly object _cRMContext;


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

        public object ApiDriverRequestField => throw new NotImplementedException();

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
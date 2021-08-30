using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;

namespace CRMRepository
{
    public interface IRepositoryWrapper
    {
        IApiDriverRepos ApiDriver { get; }
        object ApiDriverRequestField { get; }

        void Save();
    }
}
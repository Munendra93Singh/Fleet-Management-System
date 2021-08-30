using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Models;

namespace FleetManagementRepository.Repository
{
    
    public class ParentBranchRepos : RepositoryBase<ParentBranch>, IParentBranchRepos
    {
        public ParentBranchRepos(CRMContext cRMContext) : base(cRMContext)
        {

        }
    }
}

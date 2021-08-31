﻿using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using FleetManagementRepository.IRepository;

namespace CRMRepository
{
    public interface IRepositoryWrapper
    {
        IApiDriverRepos ApiDriver { get; }
        IParentBranchRepos ParentBranch { get; }
        ITruckTypeRepos TruckType { get; }
        ITruckDetailsRepos TruckDetails { get; }
        ITruckCompartmentRepos TruckCompartment { get; }
        void Save();
    }
}
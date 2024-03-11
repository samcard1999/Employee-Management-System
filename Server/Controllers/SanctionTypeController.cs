﻿using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class SanctionTypeController(IGenericRepositoryInterface<SanctionType> genericRepositoryInterface)
        : GenericController<SanctionType>(genericRepositoryInterface)
    {
 
    }
}

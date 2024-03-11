using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class SanctionController(IGenericRepositoryInterface<Sanction> genericRepositoryInterface)
        : GenericController<Sanction>(genericRepositoryInterface)
    {
    }
}

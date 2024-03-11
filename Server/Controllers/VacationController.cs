using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class VacationController(IGenericRepositoryInterface<Vacation> genericRepositoryInterface)
        : GenericController<Vacation>(genericRepositoryInterface)
    {
    }
}

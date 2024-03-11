using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class OvertimeTypeController(IGenericRepositoryInterface<OvertimeType> genericRepositoryInterface)
        : GenericController<OvertimeType>(genericRepositoryInterface)
    {
    }
}

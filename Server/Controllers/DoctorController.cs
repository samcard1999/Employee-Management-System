using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    public class DoctorController(IGenericRepositoryInterface<Doctor> genericRepositoryInterface)
        : GenericController<Doctor>(genericRepositoryInterface)
    {
    }
}

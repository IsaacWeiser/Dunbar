using Dunbar.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dunbar.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository uzrRepo)
        {
            _userRepo = uzrRepo;
        }
        public IActionResult Index()
        {
            return View(_userRepo.GetAll());
        }
    }
}

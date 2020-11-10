using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plans.DomainModel.Plans;
using Plans.DomainModel.Users;
using Plans.Repositories.DbContexts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Plans.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlansDbContext _dbContext;


        public HomeController(PlansDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = new User { Name = "Andrey", LastName="Nasevich", Login="andrey_ssss"};
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Content("Andrey Nasevich was created");
        }
    }
}

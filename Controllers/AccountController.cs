using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AccountController> _logger;
        private readonly SampleDBContext dataContext;

        public AccountController(ILogger<AccountController> logger, SampleDBContext _context)
        {
            _logger = logger;
            dataContext = _context;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {            
            return dataContext.Accounts.ToArray();
        }

        [HttpPost]
        public int Post()
        {
            //using (var dataContext = new SampleDBContext())
            {
                dataContext.Accounts.Add(new Account() { Id = 1, Name = "Krad" });
                dataContext.Accounts.Add(new Account() { Id = 2, Name = "Dev" });
                dataContext.SaveChanges();

                foreach (var cat in dataContext.Accounts.ToList())
                {
                    Console.WriteLine($"Id= {cat.Id}, Name = {cat.Name}");
                }
            }
            return 1;
        }
    }
}

using Bogus;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var faker = new Faker<Customer>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                 .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                 .RuleFor(u => u.LastName, f => f.Person.LastName)
                 .RuleFor(u => u.IsRemoved, f => f.Random.Bool(0.3f))
                 .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

            var customers = faker.Generate(100);

            return customers;
        }
    }
}

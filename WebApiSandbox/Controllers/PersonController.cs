using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSandbox.Repository.Repositories;
using WebApiSandbox.Models;
using WebApiSandbox.Services;

namespace WebApiSandbox.Controllers
{
    public class PersonController : ApiController
    {
        IBaseRepository repository;

        public PersonController()
        {
            repository = new BaseRepository();
        }

        public PersonController(IBaseRepository _repo)
        {
            repository = _repo;
        }

        public IList<ViewModel.Person> Get() => repository.Get<Person>().Select(p => p.ConvertToViewModel()).ToList();

        public ViewModel.Person Get(int id) => repository.Get<Person>(id).ConvertToViewModel();

        public ViewModel.Person Post(ViewModel.Person person) => repository.Post<Person>(person.ConvertToModel()).ConvertToViewModel();
    }
}

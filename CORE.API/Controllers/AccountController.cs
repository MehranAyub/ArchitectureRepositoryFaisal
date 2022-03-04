using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace CORE.API.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public AccountController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

       
    }
}
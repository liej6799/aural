using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aural_server_api.Controllers.Console
{
    public class StartupController : Controller
    {
        public IActionResult Index()
        {
            return "awd";
        }
    }
}
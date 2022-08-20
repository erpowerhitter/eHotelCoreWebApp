using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controller
{
    public class BaseController : ControllerBase
    {
        //This Class will be used for the base class
        public IActionResult Index()
        {
            return null;
        }
    }
}

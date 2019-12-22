using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vuex_personal.Controllers.Api
{
    public class GetNamesController: Controller
    {
        // contact data source
        public IActionResult GetNames()
        {
            // Contacts a service
            return Json("Vue Names will appear here...");
        }
    }
}

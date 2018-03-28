using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dispatch;
using Dispatch.Models;
using System.Threading.Tasks;

namespace DispatchWeb.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IEnumerable<Organization>> Organizations()
        {
            var list = await _DispatchClient.ListOrganizationsAsync();
            return list.Organizations;
        }
    }
}

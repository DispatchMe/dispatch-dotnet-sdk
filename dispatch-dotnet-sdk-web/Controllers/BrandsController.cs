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
    public class BrandsController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IEnumerable<Brand>> Brands()
        {
            var list = await _DispatchClient.ListBrandsAsync();
            return list.Brands;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixMdm.Data;
using NixMdm.Models;

using NixMdm.GoogleAPI.AndroidManagement;

using Google.Apis.AndroidManagement.v1;
using Google.Apis.Auth.AspNetCore3;

namespace NixMdm.Controllers
{
    public partial class DeviceController : Controller
    {
        [HttpGet("/Device/{id}")]
        public async Task<ActionResult<NixMdm.Models.Device>> GetDevice([FromRoute]int id) 
        {
            var device = await _context.Device.FindAsync(id);
            return device;
        }

        [HttpPost]
        public IActionResult LockScreen(int id)
        {
            return Ok();
        }

        [HttpGet]
        [GoogleScopedAuthorize(AndroidManagementService.ScopeConstants.Androidmanagement)]
        public async Task<ActionResult> GetSignupUrl([FromServices] IGoogleAuthProvider auth)
        {
            EnterpriseClient enterpriseClient = new EnterpriseClient();
            string signupUrl = await enterpriseClient.GetSignupUrl(auth);
            return View(signupUrl);
        }
    }
}
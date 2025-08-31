using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        
    }
}

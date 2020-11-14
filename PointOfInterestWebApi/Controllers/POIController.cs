using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfInterestWebApi.Data;
using PointOfInterestWebApi.Models;

namespace PointOfInterestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class POIController : ControllerBase
    {
        private readonly POIContext _context;

        public POIController(POIContext context)
        {
            _context = context;
        }

        public List<PointOfInterest>  GetAll() => _context.POI.ToList();
        

    }
}

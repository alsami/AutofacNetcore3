﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AutofacNetcore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITenantService tenantService;

        public ValuesController(ITenantService tenantService) => this.tenantService = tenantService;

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new [] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

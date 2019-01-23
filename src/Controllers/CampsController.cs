using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;
        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task <IActionResult> GetCamps()
        {
            try
            {
                var result = await _repository.GetAllCampsAsync();
                CampModel[] models = _mapper.Map<CampModel[]>(result);
                return Ok(models);
            }
            catch (Exception)
            {
                return BadRequest("database fails");
            }

            
           
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

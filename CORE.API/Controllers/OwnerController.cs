using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CORE.API.Controllers
{
    [Route("api/owner/")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public OwnerController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners(); 
                 
                return Ok(owners);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(int id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner == null)
                { 
                    return NotFound();
                }
                else
                {  
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetails(id);
                if (owner == null)
                { 
                    return NotFound();
                }
               
                   return new JsonResult(owner);

            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody]Owner owner)
        {
            try
            {
                if (owner == null)
                { 
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                { 
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repository.Owner.CreateOwner(ownerEntity);
                _repository.Save();
                 

                return CreatedAtRoute("OwnerById", new { id = ownerEntity.OwnerId }, ownerEntity);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, [FromBody]Owner owner)
        {
            try
            {
                if (owner == null)
                { 
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                { 
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _repository.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                { 
                    return NotFound();
                }

                _mapper.Map(owner, ownerEntity);

                _repository.Owner.UpdateOwner(ownerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner == null)
                { 
                    return NotFound();
                }

                //if (_repository.Account.AccountsByOwner(id).Any())
                //{ 
                //    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                //}

                _repository.Owner.DeleteOwner(owner);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
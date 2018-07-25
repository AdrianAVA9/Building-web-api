using AutoMapper;
using ExpenseTracker.Dtos;
using ExpenseTracker.Persistance;
using ExpenseTracker.Persistance.Entities;
using ExpenseTracker.Persistance.IRepositories;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Api.Controllers
{
    [RoutePrefix("api")]
    public class ExpenseGroupController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ExpenseGroupController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("expenseGroups")]
        public IHttpActionResult GetExpenseGroups()
        {
            try
            {
                var expenseGroups = _unitOfWork.ExpenseGroups.GetExpensesGroups();

                return Ok(_mapper.Map<ExpenseGroupDto>(expenseGroups));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("expenseGroup/id")]
        public IHttpActionResult GetExpenseGroup(int id, string userId)
        {
            try
            {
                var expenseGroup = _unitOfWork.ExpenseGroups.GetExpenseGroup(id, userId);

                if (expenseGroup == null)
                    return NotFound();

                return Ok(_mapper.Map<ExpenseGroupDto>(expenseGroup));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddExpenseGroup([FromBody]ExpenseGroupDto expenseGroupDto)
        {
            if (expenseGroupDto == null)
                return BadRequest();

            var result = _unitOfWork.ExpenseGroups.AddExpenseGroup((_mapper.Map<ExpenseGroup>(expenseGroupDto)));

            if(result.Status == RepositoryActionStatus.Created)
            {
                var newExpenseGroup = _mapper.Map<ExpenseGroupDto>(result.Entity);

                return Created(Request.RequestUri + "/" + newExpenseGroup.Id.ToString(),newExpenseGroup);
            }

            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult EditExpenseGroup(int id,[FromBody]ExpenseGroupDto expenseGroupDto)
        {
            try
            {
                if (expenseGroupDto == null)
                    return BadRequest();

                var result = _unitOfWork.ExpenseGroups.EditExpenseGroup(_mapper.Map<ExpenseGroup>(expenseGroupDto));

                if (result.Status == RepositoryActionStatus.NotFound)
                    return NotFound();

                if (result.Status == RepositoryActionStatus.Updated)
                    return Ok(_mapper.Map<ExpenseGroupDto>(result.Entity));

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult PatchExpenseGroup(int id,JsonPatchDocument<ExpenseGroupDto> expenseGroupPatchDocument)
        {
            try
            {
                if (expenseGroupPatchDocument == null)
                    return BadRequest();

                var expenseGroup = _unitOfWork.ExpenseGroups.GetExpenseGroup(id);

                if (expenseGroup == null)
                    return NotFound();

                var expenseGroupDto = _mapper.Map<ExpenseGroupDto>(expenseGroup);

                expenseGroupPatchDocument.ApplyTo(expenseGroupDto);

                var result = _unitOfWork.ExpenseGroups.EditExpenseGroup(_mapper.Map<ExpenseGroup>(expenseGroupDto));

                if (result.Status == RepositoryActionStatus.Updated)
                    return Ok(_mapper.Map<ExpenseGroupDto>(result.Entity));

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteExpenseGroup(int id)
        {
            try
            {
                var result = _unitOfWork.ExpenseGroups.DeleteExpenseGroup(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                    return StatusCode(HttpStatusCode.NoContent);

                if (result.Status == RepositoryActionStatus.NotFound)
                    return NotFound();

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}

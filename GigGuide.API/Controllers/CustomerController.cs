using AutoMapper;
using GigGuide.API.Controllers.Enums;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GigGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(await _unitOfWork.Customers.All()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(_mapper.Map<CustomerDto>(await _unitOfWork.Customers.Find(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            Customer item;
            try
            {
                item = _mapper.Map<Customer>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                bool itemExists = await _unitOfWork.Customers.DoesItemExist(item.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    ErrorCode.ItemIDInUse.ToString());
                }

                item.Id = default;

                _unitOfWork.Customers.Insert(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(_mapper.Map<CustomerDto>(item));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CustomerDto dto)
        {
            Customer item;
            try
            {
                item = _mapper.Map<Customer>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                var existingItem = await _unitOfWork.Customers.Find(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                //_todoRepository.Update(item);
                _unitOfWork.Customers.Update(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            //return NoContent();
            return Ok(_mapper.Map<CustomerDto>(item));
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Use the UnitOfWork to get the customer by credentials
            var customer = await _unitOfWork.Customers.GetCustomerByCredentialsAsync(email, password);

            if (customer == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }





        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Customer? item;
        //    try
        //    {
        //        item = await _unitOfWork.Customers.Find(id);
        //        if (item == null)
        //        {
        //            return NotFound(ErrorCode.RecordNotFound.ToString());
        //        }
        //        //_todoRepository.Delete(id);
        //        _unitOfWork.Customers.Delete(id);
        //        int affectedItems = await _unitOfWork.Complete();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
        //    }
        //    //return NoContent();
        //    return Ok(_mapper.Map<CustomerDto>(item));
        //}
    }
}

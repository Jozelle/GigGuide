using AutoMapper;
using GigGuide.API.Controllers.Enums;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;
using GigGuide.Data.Repository;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_mapper.Map<IEnumerable<Customer>>(await _unitOfWork.Customers.All()));
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer? item;
            try
            {
                item = await _unitOfWork.Customers.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                //_todoRepository.Delete(id);
                _unitOfWork.Customers.Delete(id);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            //return NoContent();
            return Ok(_mapper.Map<CustomerDto>(item));
        }
    }
}

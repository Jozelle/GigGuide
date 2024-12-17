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
    public class ConcertController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ConcertController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(_mapper.Map<IEnumerable<Concert>>(await _unitOfWork.Concerts.All()));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConcertDto dto)
        {
            Concert item;
            try
            {
                item = _mapper.Map<Concert>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                bool itemExists = await _unitOfWork.Concerts.DoesItemExist(item.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    ErrorCode.ItemIDInUse.ToString());
                }
                _unitOfWork.Concerts.Insert(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(_mapper.Map<ConcertDto>(item));
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ConcertDto dto)
        {
            Concert item;
            try
            {
                item = _mapper.Map<Concert>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                var existingItem = await _unitOfWork.Concerts.Find(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                //_todoRepository.Update(item);
                _unitOfWork.Concerts.Update(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            //return NoContent();
            return Ok(_mapper.Map<ConcertDto>(item));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Concert? item;
            try
            {
                item = await _unitOfWork.Concerts.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }

                _unitOfWork.Concerts.Delete(id);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }

            return Ok(_mapper.Map<ConcertDto>(item));
        }
    }
}

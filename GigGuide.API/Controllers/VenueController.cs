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
    public class VenueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VenueController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(_mapper.Map<IEnumerable<Venue>>(await _unitOfWork.Venues.All()));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VenueDto dto)
        {
            Venue item;
            try
            {
                item = _mapper.Map<Venue>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                bool itemExists = await _unitOfWork.Venues.DoesItemExist(item.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    ErrorCode.ItemIDInUse.ToString());
                }
                _unitOfWork.Venues.Insert(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(_mapper.Map<VenueDto>(item));
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] VenueDto dto)
        {
            Venue item;
            try
            {
                item = _mapper.Map<Venue>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                var existingItem = await _unitOfWork.Venues.Find(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Venues.Update(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return Ok(_mapper.Map<VenueDto>(item));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Venue? item;
            try
            {
                item = await _unitOfWork.Venues.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Venues.Delete(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return Ok(_mapper.Map<VenueDto>(item));

        }
    }
}

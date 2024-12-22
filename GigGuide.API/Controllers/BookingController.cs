using AutoMapper;
using GigGuide.API.Controllers.Enums;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GigGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(_mapper.Map<IEnumerable<Booking>>(await _unitOfWork.Bookings.All()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            return Ok(_mapper.Map<Booking>(await _unitOfWork.Bookings.Find(id)));
        }

        [HttpGet("{performanceId}/{customerId}")]
        public async Task<IActionResult> GetBookingByPerformanceAndCustomer(int performaceId, int customerId)
        {
            return Ok(_mapper.Map<Booking>(await _unitOfWork.Bookings.GetBookingByPerformanceAndCustomer(performaceId, customerId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingDto dto)
        {
            Booking item;
            try
            {
                item = _mapper.Map<Booking>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                bool itemExists = await _unitOfWork.Bookings.DoesItemExist(item.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    ErrorCode.ItemIDInUse.ToString());
                }
                _unitOfWork.Bookings.Insert(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(_mapper.Map<BookingDto>(item));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] BookingDto dto)
        {
            Booking item;
            try
            {
                item = _mapper.Map<Booking>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                var existingItem = await _unitOfWork.Bookings.Find(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Bookings.Update(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return Ok(_mapper.Map<BookingDto>(item));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            Booking? item;
            try
            {
                item = await _unitOfWork.Bookings.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Bookings.Delete(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return Ok(_mapper.Map<BookingDto>(item));
        }
    }

 }



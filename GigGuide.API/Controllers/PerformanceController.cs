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

    public class PerformanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PerformanceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(_mapper.Map<IEnumerable<Performance>>(await _unitOfWork.Performances.All()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformanceByConcert(int id)
        {
            return Ok(_mapper.Map<IEnumerable<Performance>>(await _unitOfWork.Performances.GetPerformancesByConcert(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerformanceDto dto)
        {
            Performance item;
            try
            {
                item = _mapper.Map<Performance>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                bool itemExists = await _unitOfWork.Performances.DoesItemExist(item.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                    ErrorCode.ItemIDInUse.ToString());
                }
                _unitOfWork.Performances.Insert(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(_mapper.Map<PerformanceDto>(item));
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PerformanceDto dto)
        {
            Performance item;
            try
            {
                item = _mapper.Map<Performance>(dto);
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.AdditionalInformationRequired.ToString());
                }
                var existingItem = await _unitOfWork.Performances.Find(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Performances.Update(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return Ok(_mapper.Map<PerformanceDto>(item));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Performance? item;
            try
            {
                item = await _unitOfWork.Performances.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _unitOfWork.Performances.Delete(item);
                int affectedItems = await _unitOfWork.Complete();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }

            return Ok(_mapper.Map<PerformanceDto>(item));
        }
    }
}

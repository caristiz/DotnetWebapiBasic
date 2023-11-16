using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _VaccineRepository;
        private readonly IValidator<VaccineRequestDto> _validator;

        public VaccineController(IVaccineService vaccineService, IValidator<VaccineRequestDto> validator)
        {
            _VaccineRepository = vaccineService;
            _validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccine = await _VaccineRepository.GetAll();
            return Ok(vaccine);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccine = await _VaccineRepository.GetById(id);
            return Ok(vaccine);
        }



        [HttpPost]
        public async Task<IActionResult> Create(VaccineRequestDto vaccineDto)
        {
            var validationResult = await _validator.ValidateAsync(vaccineDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var vaccine = await _VaccineRepository.Add(vaccineDto);
            return Ok(vaccine);
        }

        //    var dependent = _mapper.Map<Dependent>(dependentsDto);
        //    await _dependentRepository.Add(dependent);

        //    return CreatedAtAction(nameof(GetById), new { id = dependent.Id }, dependent);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineRequestDto vaccineDto)
        {

            var vaccine = await _VaccineRepository.Update(vaccineDto, id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return Ok(vaccine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccine = await _VaccineRepository.Delete(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return Ok(vaccine);
        }



    }
}

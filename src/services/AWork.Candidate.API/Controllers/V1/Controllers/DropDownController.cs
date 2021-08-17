using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Core.DomainObjects;
using AWork.WebAPI.Core.Controllers;
using AWork.WebAPI.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AWork.Candidatos.API.Controllers.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/dropdown")]
    public class DropDownController : MainController
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IAspNetUser _appUser;
        private readonly Guid _candidateId;

        public DropDownController(ICandidateRepository candidateRepository, IAspNetUser appUser)
        {
            _candidateRepository = candidateRepository;
            _appUser = appUser;
            _candidateId = appUser.CandidateId;
        }

        [HttpGet("marital-status")]
        public async Task<ActionResult<IList<Dropdown>>> GetMaritalStatus()
        {
            var dropdown = await _candidateRepository.DropdownMaritalStatus();
            return CustomResponse(dropdown);
        }
        [HttpGet("nationality")]
        public async Task<ActionResult<IList<Dropdown>>> GetNationality()
        {
            var dropdown = await _candidateRepository.DropdownNationality();
            return CustomResponse(dropdown);
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IList<Dropdown>>> GetCountries()
        {
            var dropdown = await _candidateRepository.DropdownCountries();
            return CustomResponse(dropdown);
        }

        [HttpGet("religion")]
        public async Task<ActionResult<IList<Dropdown>>> GetReligion()
        {
            var dropdown = await _candidateRepository.DropdownReligion();
            return CustomResponse(dropdown);
        }

        [HttpGet("occupation-area")]
        public async Task<ActionResult<IList<Dropdown>>> GetOccupationArea()
        {
            var dropdown = await _candidateRepository.DropdownOccupationArea();
            return CustomResponse(dropdown);
        }

        [HttpGet("occupation/{occupationArea:guid}")]
        public async Task<ActionResult<IList<Dropdown>>> GetOccupation(Guid occupationArea)
        {
            var dropdown = await _candidateRepository.DropdownOccupation(occupationArea);
            return CustomResponse(dropdown);
        }

        [HttpGet("languages")]
        public async Task<ActionResult<IList<Dropdown>>> GetLanguages()
        {
            var dropdown = await _candidateRepository.DropdownLanguage(_candidateId);
            return CustomResponse(dropdown);
        }
    }
}

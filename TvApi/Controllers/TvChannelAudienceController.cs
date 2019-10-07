using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TvApi.Applications;
using TvApi.Context;
using TvApi.Domain.DTO;
using TvApi.Domain.Interfaces;
using TvApi.Models;

namespace TvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceTvChannelController : ControllerBase
    {
        private readonly IAudienceTvChannelService AudienceTvChannelService;

        public AudienceTvChannelController(IAudienceTvChannelService audienceTvChannelService)
        {
            AudienceTvChannelService = audienceTvChannelService;
        }

        [HttpDelete("audience/{audienceId}")]
        public IActionResult DeleteAudience(long audienceId)
        {
            try
            {
                AudienceTvChannelService.RemoveAudience(audienceId);
                return Accepted();
            }
            catch (Exception ex)
            {
                return StatusCode(406);
            }
        }
        [HttpDelete("tv/{tvId}")]
        public IActionResult DeleteTvChannel(long tvId)
        {
            try
            {
                AudienceTvChannelService.RemoveTvChannel(tvId);
                return Accepted();
            }
            catch (Exception ex)
            {
                return StatusCode(406);
            }
        }
        [HttpPut("audience/update/{audienceId}")]
        public IActionResult UpdateAudience(long audienceId, [FromBody] Audience audience)
        {
            try
            {
                AudienceTvChannelService.UpdateAudience(audienceId, audience);
                return Accepted();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }

        }
        [HttpPut]
        public IActionResult UpdateTvChannel(long tvId, [FromBody] TvChannel tvChannel)
        {
            try
            {
                AudienceTvChannelService.UpdateTvChannel(tvId, tvChannel);
                return Accepted();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPost("audience/{tvId}")]
        public IActionResult CreateAudience(long tvId, Audience audience)
        {
            try
            {
                AudienceTvChannelService.CreateAudience(tvId, audience);
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("tv")]
        public IActionResult CreateTvChannel(TvChannel tvChannel)
        {
            try
            {
                AudienceTvChannelService.CreateTvChannel(tvChannel);
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("audience/{audienceId}")]
        public IActionResult GetAudienceById(long audienceId)
        {
            Audience audience = AudienceTvChannelService.GetAudienceById(audienceId);
            if (audience == null)
            {
                return NotFound("Name not found");
            }
            return Ok(audience);
        }
        [HttpGet("tv/{tvId}")]
        public IActionResult GetTvChannelById(long tvId)
        {
            TvChannel tvChannel = AudienceTvChannelService.GetTvChannelById(tvId);
            if (tvChannel == null)
            {
                return NotFound("Id not found");
            }
            return Ok(tvChannel);
        }
        [HttpGet("name/{name}")]
        public IActionResult GetTvChannelByName(string name)
        {
            TvChannel tvChannel = AudienceTvChannelService.GetTvChannelByName(name);
            if (tvChannel == null)
            {
                return NotFound("Name not found");
            }
            return Ok(tvChannel);
        }
        [HttpGet("date-desired/{dateDesired}")]
        public IActionResult ListAudienceWithTvChannelHour(string dateDesired)
        {
            return Ok(AudienceTvChannelService.ListAudiencesTvChannelWithAvarageHour(dateDesired));
        }
        [HttpGet("find/audience")]
        public IActionResult ListAudience()
        {
            return Ok(AudienceTvChannelService.ListAudience());
        }
        [HttpGet("find/tvChannel")]
        public IActionResult ListTvChannel()
        {
            return Ok(AudienceTvChannelService.ListTvChannel());
        }

    }
}
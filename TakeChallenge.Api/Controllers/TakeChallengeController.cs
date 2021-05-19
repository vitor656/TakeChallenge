using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TakeChallenge.Domain.Commands.Responses;
using TakeChallenge.Domain.Handlers;

namespace TakeChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/v1/TakeChallenge")]
    public class TakeChallengeController : ControllerBase
    {

        [HttpGet]
        [Route("TakeProjects")]
        public async Task<List<TakeProjectViewModel>> TakeProjects([FromServices] ITakeProjectsHandler takeProjectsHandle)
        {
            var handlerResponse = await takeProjectsHandle.HandleAsync();
            return handlerResponse.TakeProjects;
        }
    }
}
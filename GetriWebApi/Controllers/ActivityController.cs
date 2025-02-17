using Application.Activities;
using Application.Core;
using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetriWebApi.Controllers
{
    public class ActivityController : BaseApiController
    {
       
        [HttpGet]
        public async Task<IActionResult> GetActivities(CancellationToken ct) {
            return HandleRequest(await Mediator.Send(new List.Query(), ct));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActivity(Guid Id)
        {
            return HandleRequest(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity Activity)
        {
            return HandleRequest(await Mediator.Send(new Create.Command { Activity = Activity }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateActivity(Guid Id, Activity Activity)
        {
            Activity.Id = Id;
            return HandleRequest(await Mediator.Send(new Edit.Command { Activity = Activity }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            return HandleRequest(await Mediator.Send(new Delete.Command { Id = Id }));   
        }
    }
}

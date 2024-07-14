using Application.Features.Notifications.Commands.MarkAsRead;
using Application.Features.Notifications.Commands.SendNotification;
using Application.Features.Notifications.Queries.GetList;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification(SendNotificationCommand command)
        {
            SendNotificationResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var command = new MarkAsReadCommand { NotificationId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{receiverId}")]
        public async Task<IActionResult> GetNotifications([FromRoute] int receiverId)
        {
            GetNotificationsQuery query = new() { ReceiverId = receiverId };
            List<GetNotificationsResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}

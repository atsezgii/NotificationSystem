using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Commands.SendNotification
{
    public class SendNotificationCommand : IRequest<SendNotificationResponse>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Contents { get; set; }
        public DateTime PostedDate { get; set; }

        public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, SendNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public SendNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }


            public async Task<SendNotificationResponse> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification notification = _mapper.Map<Notification>(request);
                await _notificationRepository.AddAsync(notification);
                SendNotificationResponse response = _mapper.Map<SendNotificationResponse>(notification);
                return response;
            }
        }

    }
}

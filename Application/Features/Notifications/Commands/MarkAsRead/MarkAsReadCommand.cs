using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Notifications.Commands.MarkAsRead
{
    public class MarkAsReadCommand:IRequest<MarkAsReadResponse>
    {
        public int NotificationId { get; set; }

        public class MarkAsReadCommandHandler : IRequestHandler<MarkAsReadCommand, MarkAsReadResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public MarkAsReadCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<MarkAsReadResponse> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
            {
                var notification = await _notificationRepository.GetByIdAsync(request.NotificationId);

                if (notification == null)
                    throw new Exception("Notification not found");

                notification.ReadStatus = true;
                await _notificationRepository.UpdateAsync(notification);

                var response = _mapper.Map<MarkAsReadResponse>(notification);
                return response;
            }
        }
    }
}

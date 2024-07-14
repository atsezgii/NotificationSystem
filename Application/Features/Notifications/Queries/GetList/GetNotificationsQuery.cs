
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Queries.GetList
{
    public class GetNotificationsQuery:IRequest<List<GetNotificationsResponse>>
    {
        public int ReceiverId { get; set; }// Bildirimleri alan kullanıcının ID'si
        public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<GetNotificationsResponse>>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public GetNotificationsQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<List<GetNotificationsResponse>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
            {

                var notifications = await _notificationRepository.GetAsync(n => n.ReceiverId == request.ReceiverId && !n.IsDeleted);

                var response = _mapper.Map<List<GetNotificationsResponse>>(notifications);
                return response;
            }
        }
    }
}

using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    //private readonly IOrderRepository _orderRepository;
    //private readonly IMapper _mapper;
    //public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    //{
    //    _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    //}
    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //var orderEntity = _mapper.Map<Order>(request.Order);
        //var newOrder = await _orderRepository.AddAsync(orderEntity);
        //return new CreateOrderResult(newOrder.Id);

        throw new NotImplementedException();
    }
}
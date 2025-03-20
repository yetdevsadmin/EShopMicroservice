using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints;


public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool isSuccess);


public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderCommand>();
            var result = await sender.Send(command, default);
            var response = result.Adapt<UpdateOrderResponse>();

            return Results.Ok(result);
        })
        .WithName("UpdateOrder")
        .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Updates an order")
        .WithDescription("Updates an order in the system");
    }
}

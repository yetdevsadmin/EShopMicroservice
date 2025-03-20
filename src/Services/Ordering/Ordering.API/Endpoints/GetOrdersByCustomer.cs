﻿using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints;

//public record class GetOrdersByCustomerRequest(Guid CustomerId);

public record class GetOrdersByCustomerResponse(List<OrderDto> Orders);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (Guid CustomerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByCustomerQuery(CustomerId));
            var response = result.Adapt<GetOrdersByCustomerResponse>();
            return Results.Ok(response);
        })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get orders by customer")
        .WithDescription("Gets orders by customer in the system");
    }
}

﻿namespace Basket.API.Basket.DeleteBasket;

//public record DeleteBasketRequest(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{username}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        })
         .WithName("DeleteBasket")
         .Produces<DeleteBasketResult>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithSummary("Delete the basket for a user")
         .WithDescription("Delete the basket for a user");
    }
}   

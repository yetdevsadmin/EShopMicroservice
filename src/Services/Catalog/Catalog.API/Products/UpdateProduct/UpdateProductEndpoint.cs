﻿namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest
    (
        Guid Id,
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
    );

public record UpdateProductResponse(bool isSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            return Results.Ok(result);

        })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Update Proudct")
            .WithDescription("Update Proudct");
    }
}


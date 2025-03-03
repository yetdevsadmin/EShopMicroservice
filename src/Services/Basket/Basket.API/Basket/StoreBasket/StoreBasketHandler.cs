namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandvalidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandvalidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Car can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand commad, CancellationToken cancellationToken)
    {
        ShoppingCart cart = commad.Cart;
        //to do: save basket to repository
        //update cache

        return new StoreBasketResult("SWn");
    }
}

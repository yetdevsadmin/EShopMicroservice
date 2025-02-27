namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHanlder(IDocumentSession session, ILogger<GetProductByCategoryQueryHanlder> logger) 
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryQueryHanlder.Handle called with {@query}", query);

            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();

            return new GetProductByCategoryResult(products);

        }
    }
}

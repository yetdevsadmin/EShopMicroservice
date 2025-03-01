using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

           // if (await session.Query<Product>().AnyAsync())
               // return;

            //Marten UPSERT will cater for existing records
            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>
            {
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b3"),
                    Name = "IPhone X",
                    Description = "Description IPhone X",
                    ImageFile = "product1.png",
                    Price = 950.00M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b4"),
                    Name = "Samsung 10",
                    Description = "Description for Samsung 10",
                    ImageFile = "Samsung.png",
                    Price = 500.00M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b5"),
                    Name = "Barbie Doll",
                    Description = "Description for Barbie",
                    ImageFile = "Barbie.png",
                    Price = 10.00M,
                    Category = new List<string> { "Doll" }
                },
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b6"),
                    Name = "Billy Doll",
                    Description = "Description for Billy",
                    ImageFile = "Billy.png",
                    Price = 12.00M,
                    Category = new List<string> { "Doll" }
                },
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b7"),
                    Name = "Blue ink pen",
                    Description = "Description for Blue pen",
                    ImageFile = "Bluepen.png",
                    Price = 10.00M,
                    Category = new List<string> { "Pen" }
                },
                new Product
                {
                    Id = new Guid("f5b3b8f4-cc2f-4f3f-8f1d-6f6f94f6e1b8"),
                    Name = "Red ink pen ",
                    Description = "Description Red pen",
                    ImageFile = "Redpen.png",
                    Price = 12.00M,
                    Category = new List<string> { "Pen" }
                }
            };
    }
}

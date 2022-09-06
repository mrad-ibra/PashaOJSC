using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Repositories;
using System.Collections.Generic;
using System.Linq;
namespace ProductApi.Tests
{
    public class CategoryTest
    {

        private static DbContextOptions<ProductDbContext> dbContextOptions = new DbContextOptionsBuilder<ProductDbContext>()
             .UseInMemoryDatabase(databaseName: "ProductapiDb")
             .Options;

        ProductDbContext context;
        ProductCategoryRepository categoryRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new ProductDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            categoryRepository = new ProductCategoryRepository(context);
        }

        [Test, Order(1)]
        public void GetAllCategories_Test()
        {
            var result = categoryRepository.GetAllProductCategorysAsync();
            Assert.That(result.Count), Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

        [Test, Order(2)]
        public void GetCategoryById_TestWithResponse()
        {
            var result = categoryRepository.GetProductCategoryByIdAsync(1);
            Assert.That(result.ProductCategoryId, Is.EqualTo(1));
            Assert.That(result.ProductCategoryName, Is.EqualTo("first"));
        }

        [Test, Order(3)]
        public void AddCategory_Test()
        {
            var category = new ProductCategory()
            {
                ProductCategoryName = "my Category"
            };
            var result = categoryRepository.CreateProductCategoryAsync(category);
            Assert.That(result, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            var categories = new List<ProductCategory>
            {
                new ProductCategory { ProductCategoryId = 1,ProductCategoryName ="first" },
                new ProductCategory { ProductCategoryId = 2,ProductCategoryName ="second" },
                new ProductCategory { ProductCategoryId = 3,ProductCategoryName ="third" },
            };
            context.ProductCategories.AddRange(categories);
            context.SaveChanges();
        }
    }
}

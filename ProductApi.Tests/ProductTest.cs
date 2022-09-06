using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Tests
{
    public class ProductTest {

        private static DbContextOptions<ProductDbContext> dbContextOptions = new DbContextOptionsBuilder<ProductDbContext>()
               .UseInMemoryDatabase(databaseName: "ProductapiDb")
               .Options;
        ProductDbContext context;
        ProductRepository productRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new ProductDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            productRepository = new ProductRepository(context);
        }

        [Test, Order(1)]
        public void GetAllProducts_Test()
        {
            var result = productRepository.GetAllProductsAsync();
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

        [Test, Order(2)]
        public void GetProductById_TestWithResponse()
        {
            var result = productRepository.GetProductByIdAsync(1);
            Assert.That(result.ProductId, Is.EqualTo(1));
            Assert.That(result.ProductCategoryId, Is.EqualTo(1));
            Assert.That(result.State, Is.EqualTo(1));
            Assert.That(result.ProductName, Is.EqualTo("first"));
            Assert.That(result.Price, Is.EqualTo(1));
            Assert.That(result.IsDeleted, Is.EqualTo(false));
            Assert.That(result.CreatedDate, Is.EqualTo(DateTime.Today));
        }

        [Test, Order(3)]
        public void AddProduct_Test()
        {
            var resource = new ProductResource()
            {
                ProductCategoryId = 1,
                State = "new",
                ProductName = "first",
                Price = 1
            };
            var result = productRepository.CreateProductAsync(resource);
            Assert.That(result, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            var products = new List<Product>
            {
                new Product {ProductId=1, ProductCategoryId = 1,State ="first",ProductName="first", Price=1,IsDeleted=false },
                new Product {ProductId=2, ProductCategoryId = 3,State ="second",ProductName="second", Price=1,IsDeleted=false },
                new Product {ProductId=3, ProductCategoryId = 2,State ="third",ProductName="third", Price=1,IsDeleted=false },
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
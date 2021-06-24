using System;
using System.Linq;
using AWSWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AWSWebApi.Controllers
{
    /// <summary>
    /// Контроллер магазина. 
    /// </summary>
    [ApiController]
    [Route("Shop")]
    public class MainController : ControllerBase
    {
        private WebShopContext Context { get; set; }

        public MainController(WebShopContext context)
        {
            Context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Context.Products.ToList());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(Context.Products.ToList().FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public JsonResult Post()
        {
            var rand = (new Random()).Next();
            Context.Products.Add(new Product() {Name = "TestProduct" + rand, Price = rand});
            Context.SaveChanges();
            return new JsonResult("Product added");
        }

        [HttpPut("{num}/add")]
        public JsonResult Put(int num)
        {
            var rand = new Random();
            for (int i = 0; i < num; i++)
            {
                Context.Products.Add(new Product() { Name = "TestProduct" + rand.Next(), Price = rand.Next() });
            }
            Context.SaveChanges();
            return new JsonResult($"{num} products added");
        }

        [HttpDelete("{id}/delete")]
        public JsonResult Delete(int id)
        {
            var rand = new Random();
            var product = Context.Products.FirstOrDefault(x => x.Id == id);
            if (product==null) return new JsonResult("Product not found");

            Context.Products.Remove(product);
            Context.SaveChanges();
            
            return new JsonResult($"{id} products added");
        }
    }
}
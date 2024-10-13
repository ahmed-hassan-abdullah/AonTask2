using AonFreelancing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AonFreelancing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //انشاء قاعدة بيانات وهمية قادمة من الموديل 
        private static List<ProductsAll> ProductsLists = new List<ProductsAll>();

        //عرض البيانات
        [HttpGet]
        public IActionResult GetAllProducts()
        {

            return Ok(ProductsLists);
        }

        //اضافة منتجات جديدة
        [HttpPost]
        public IActionResult Create([FromBody] ProductsAll productsAll)
        {
            ProductsLists.Add(productsAll);
            return CreatedAtAction("Create", new { Id = productsAll.Id }, ProductsLists);
        }

        //بحث عن منتج من خلال المعرف 
        [HttpGet("{id}")]
        public IActionResult GetProductId(int id)
        {
            var product = ProductsLists.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound("هذا المنتج غير موجود");
            }
            return Ok($"{id} تم العثور على المنتج ");        
        }

        //تحديث المنتجات

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductsAll updatedProduct)
        {
            var Product = ProductsLists.FirstOrDefault(t => t.Id == id);
            if (Product == null)
            {
                return NotFound("لا يوجد منتج لتحديثة");
            }

            //اختيار العناصر المراد تحديثها
            Product.Id = updatedProduct.Id;
            Product.Name = updatedProduct.Name;
            Product.Price = updatedProduct.Price;
            Product.Category = updatedProduct.Category;
            Product.Title = updatedProduct.Title;
            Product.Description = updatedProduct.Description;
            return Ok($"{id} تم تحديث المنتج بنجاح");
            
        }

        //حذف منتج
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductsLists.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound("لا يوجد منتج لحذفة");
            }

            ProductsLists.Remove(product);
            return Ok($"{id} تم حذف المنتج بنجاح"); 
        }

    }

}

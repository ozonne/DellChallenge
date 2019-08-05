using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(string id)
        {
            var result = _productsService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        // Put method implementation with no id parameter.
        //[HttpPut]
        //[EnableCors("AllowReactCors")]
        //public ActionResult<ProductDto> Put([FromBody] ProductDto product)
        //{
        //    var updatedProduct = _productsService.Update(product);
        //    if (updatedProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(updatedProduct);
        //}

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Delete(string id)
        {
            var result = _productsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // In oder for the product to be deserialized the string value has to be in the format "{\"Id\":\"f461e0cd-1927-4147-bf1c-d43cafb756ea\",\"name\":\"string2\",\"category\":\"string2\"}" 
        // or "{\"name\":\"string2\",\"category\":\"string2\"}" also the update method commented above uses object binding with no external id parameter.
        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Put(string id, [FromBody] string value)
        {
            var product = JsonConvert.DeserializeObject<ProductDto>(value);
            product.Id = id.ToString();
            var updatedProduct = _productsService.Update(product);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }
    }
}

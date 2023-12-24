using Application.dto;
using Application.usecase.product;
using Domain.product.entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly GetAllProducts _getProducts;
        private readonly GetProductById _getProductById;
        private readonly CreateProduct _createProduct;
        private readonly UpdateProduct _updateProduct;
        private readonly DeleteProduct _deleteProduct;
        private readonly UploadImage _uploadImage;
            
        public ProductController(
            GetAllProducts getProducts, 
            UploadImage uploadImage, 
            GetProductById getProductById, 
            CreateProduct createProduct,
            UpdateProduct updateProduct,
            DeleteProduct deleteProduct
        )

        {
            _getProducts = getProducts;
            _uploadImage = uploadImage;
            _getProductById = getProductById;
            _createProduct = createProduct;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetProducts()
        {
            var products = await _getProducts.Execute();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            var product = await _getProductById.Execute(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(ProductDTO request)
        {
            var product = await _createProduct.Execute(request);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] ProductDTO request, Guid id)
        {
            await _updateProduct.Execute(request, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var success =  await _deleteProduct.Execute(id);

            return Ok(success);
           
        }

        [HttpPost("/upload")]
        public async Task<ActionResult<string>> Upload(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return "Invalid file";
            }

            using (var ms = new MemoryStream())
            {

                var fileName = file.FileName;

                await file.CopyToAsync(ms);
                byte[] fileBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);


                string path = _uploadImage.Execute(fileName, base64String);

                return Ok(path);
            }

        }
    }
}

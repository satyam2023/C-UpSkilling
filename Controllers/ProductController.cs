namespace WebApis.Controllers.ProductController;

using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApis.Constant.UrlEndPoints;
using WebApis.Models.Dtos;

[Route($"{UrlEndPoints.product}")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private IProductService _productService;
    private IMapper _mapper;
    public ProductController(
   IProductService productService,
   IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    [HttpPost("createProduct")]
    public IActionResult Create(CreateProduct product)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Admin")
            return Forbid();
        _productService.createProduct(product);

        return Ok();
    }

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        var product = _productService.getProducts();
        return Ok(product);
    }

    [HttpGet("productDetail")]
    public IActionResult ProductDetail()
    {
        var data = _productService.getProductDetail(2);
        return Ok(data);
    }
}
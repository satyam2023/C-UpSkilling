

using AutoMapper;
using WebApis.Helpers;
using WebApis.Models.Dtos;

public interface IProductService
{
    void createProduct(CreateProduct product);
    IEnumerable<Product> getProducts();

    ProductDetail? getProductDetail(int id);

}

public class ProductService : IProductService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public ProductService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void createProduct(CreateProduct product)
    {
        var productData = _mapper.Map<Product>(product);
        _context.Products.Add(productData);
        _context.SaveChanges();
        return;
    }

    public IEnumerable<Product> getProducts()
    {
        return _context.Products;
    }

    public ProductDetail getProductDetail(int id){
        var res=_context.ProductDetails.FirstOrDefault(x=>x.ProductId==id);
        return res;
    }
}
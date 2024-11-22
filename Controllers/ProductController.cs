using ImageUploadAspNetCore.Data;
using ImageUploadAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadAspNetCore.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext _context;
        IWebHostEnvironment _environment;
        public ProductController(ProductDbContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            _environment = environment; //For uploading file
        }
        public IActionResult Index()
        {
            return View(_context.Product.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            string filename = "";
            
            if (productViewModel.photo != null)
            {
                var ext = Path.GetExtension(productViewModel.photo.FileName);
                var size = productViewModel.photo.Length;
                if (size <= 1000000)
                {
                    if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                    {
                        string folder = Path.Combine(_environment.WebRootPath, "uploads"); //To get uploads folder
                        filename = Guid.NewGuid().ToString() + "_" + productViewModel.photo.FileName; //File name with guid because the file name can be duplicate
                        string filePath = Path.Combine(folder, filename); //combining folder and filename
                        productViewModel.photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        Product product = new Product()
                        {
                            Name = productViewModel.Name,
                            Description = productViewModel.Description,
                            Price = productViewModel.Price,
                            ImagePath = filename,
                        };
                        _context.Product.Add(product);
                        _context.SaveChanges();
                        TempData["Success"] = "Product Added...";
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        TempData["ExtError"] = "Only PNG, JPG, JPEG images allowed.";
                    }
                }
                else
                {
                    TempData["SizeError"] = "Image must be less than 1 MB";
                }
            }

            return View();
        }
    }
}

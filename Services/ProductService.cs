namespace Shoes_Ecommerce.Services
{
    public class ProductService : IProductService
    {
        #region proprity
        private readonly IProductRepository productRepo;
        private readonly IGenericRepository<ProductColor> colorRepo;
        private readonly IGenericRepository<ProductSize> sizeRepo;
        private readonly IGenericRepository<ProductImage> imageRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IGenericRepository<ProductVariant> variantRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGenericRepository<UserNotification> userNotificationRepo;
        private readonly string ImagePath;
        #endregion

        #region Construtor
        public ProductService(
            IProductRepository productRepo, IGenericRepository<ProductColor> colorRepo,
            IGenericRepository<ProductSize> sizeRepo, IGenericRepository<ProductImage> ImageRepo
            , IWebHostEnvironment webHostEnvironment, ICategoryRepository categoryRepo,
            IGenericRepository<ProductVariant> VariantRepo, UserManager<ApplicationUser> userManager
            )
        {
            this.productRepo = productRepo;
            this.colorRepo = colorRepo;
            this.sizeRepo = sizeRepo;
            imageRepo = ImageRepo;
            this.categoryRepo = categoryRepo;
            variantRepo = VariantRepo;
            this.userManager = userManager;
            this.userNotificationRepo = userNotificationRepo;
            ImagePath = Path.Combine(webHostEnvironment.WebRootPath, FileSetting.ImagesPathProduct.TrimStart('/'));
        }
        #endregion

        public async Task AddProductAsync(ProductDTO productDto)
        {
            Product product = new Product();

            product.NameEn = productDto.NameEn;
            product.NameAr = productDto.NameAr;
            product.descriptionEn = productDto.descriptionEn;
            product.descriptionAr = productDto.descriptionAr;
            product.Price = productDto.Price;
            product.discount = productDto.discount;
            product.CategoryID = productDto.Category;
            product.targetGender = productDto.targetGender;

            await productRepo.AddAsync(product);
            await productRepo.Save();

            List<ProductVariantDTO> productVariants = productDto.ProductVariants;

            foreach (var VariantDTO in productVariants)
            {
                var color = new ProductColor
                {
                    hexCode = VariantDTO.colorHexCode
                };

                await colorRepo.AddAsync(color);
                await colorRepo.Save();

                var size = new ProductSize
                {
                    SizeValue = VariantDTO.sizeValue,
                    sizeName = ProductSizeName.GetSizeName(VariantDTO.sizeValue)
                };

                await sizeRepo.AddAsync(size);
                await sizeRepo.Save();

                ProductVariant productVariant = new ProductVariant
                {
                    ProductId = product.Id,
                    ColorId = color.Id,
                    SizeId = size.Id,
                    QuantityInStock = VariantDTO.QuantityInStock
                };

                await variantRepo.AddAsync(productVariant);
                await variantRepo.Save();

                product.Variants.Add(productVariant);

            }

            await SendNotificaciones.SendProductNotificationToTopic("all", "New Product!", $"A new product has been added: {product.NameEn}");

        }

        public async Task<Product> UpdateProductAsync(int productId, ProductDTO productDto)
        {
            var product = await productRepo.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            product.NameEn = productDto.NameEn;
            product.NameAr = productDto.NameAr;
            product.descriptionEn = productDto.descriptionEn;
            product.descriptionAr = productDto.descriptionAr;
            product.Price = productDto.Price;
            product.discount = productDto.discount;
            product.CategoryID = productDto.Category;
            product.targetGender = productDto.targetGender;
            product.Variants = productDto.ProductVariants.Select(v => new ProductVariant
            {
                Color = new ProductColor { hexCode = v.colorHexCode },
                Size = new ProductSize
                {
                    SizeValue = v.sizeValue,
                    sizeName = ProductSizeName.GetSizeName(v.sizeValue)
                },
                QuantityInStock = v.QuantityInStock
            }).ToList();
            productRepo.Update(product);
            await productRepo.Save();
            return product;
        }
        
        public async Task DeleteProductAsync(int productId)
        {
            var product = await productRepo.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            if(product.Images != null)
            {
                foreach (var image in product.Images)
                {
                    Images.DeleteImage(image.ImageUrl, ImagePath);
                    await imageRepo.DeleteAsync(image);
                }
            }
            
            await productRepo.DeleteAsync(productId);
            await productRepo.Save();
        }

        public async Task UploadImagesAsync(int productId, List<IFormFile> images)
        {
            if (images == null || !images.Any())
                throw new ArgumentException("No images provided.");

            var product = await productRepo.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            foreach (var image in images)
            {
                string cover = await Images.SaveImage(image, ImagePath);

                ProductImage productImage = new ProductImage
                {
                    ProductID = productId,
                    ImageUrl = cover
                };

                await imageRepo.AddAsync(productImage);
                await imageRepo.Save();

                product.Images.Add(productImage);

            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await productRepo.GetProductByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            return product;
        }

        public IEnumerable<Product> GetAllProductsWithFilter(FilterDTO filterDTO)
        {
            var products = productRepo.getAllProductWithFilter(filterDTO);
            if (products == null || !products.Any())
                return Enumerable.Empty<Product>();
            return products;
        }

        public IEnumerable<Product> GetAllProducts(int CategoryId)
        {
            Category category = categoryRepo.GetCategoryIncludeAllProducts(CategoryId);
            if (category == null)
            {
                return Enumerable.Empty<Product>();
            }
            return category.Products;
        }

        public List<Product> GetProductsInSearch(string name)
        {
            return productRepo.GetProductsInSearch(name);
        }

    
    }
}
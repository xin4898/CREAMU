using System.ComponentModel;

namespace CreamMUProduct.Models
{
    public class CProductWraper
    {
        private TProduct _product;
        public CProductWraper()
        {
            if (_product == null)
                _product = new TProduct();
        }
        public TProduct product
        {
            get { return _product; }
            set { _product = value; }
        }
        public int FId
        {
            get { return _product.ProductId; }
            set { _product.ProductId = value; }
        }
        [DisplayName("品名")]
        public string? FName
        {
            get { return _product.PName; }
            set { _product.PName = value; }
        }

        public int? PTypeId
        {
            get { return _product.PTypeId; }
            set { _product.PTypeId = value; }
        }

        public decimal? PPrice
        {
            get { return _product.PPrice; }
            set { _product.PPrice = value; }
        }

        public int? PInstock
        {
            get { return _product.PInstock; }
            set { _product.PInstock = value; }
        }
        public string? PStatus
        {
            get { return _product.PStatus; }
            set { _product.PStatus = value; }
        }
        public string? PDescript
        {
            get { return _product.PDescript; }
            set { _product.PDescript = value; }
        }
        public string? PReleaseDate
        {
            get { return _product.PReleaseDate; }
            set { _product.PReleaseDate = value; }
        }
        public int? EmployeeId
        {
            get { return _product.EmployeeId; }
            set { _product.EmployeeId = value; }
        }
        public string? PImages
        {
            get { return _product.PImages; }
            set { _product.PImages = value; }
        }
        public IFormFile photo { get; set; }
    }
}

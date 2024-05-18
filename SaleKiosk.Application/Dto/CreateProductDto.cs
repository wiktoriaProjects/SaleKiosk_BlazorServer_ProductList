using System.ComponentModel.DataAnnotations;

namespace SaleKiosk.SharedKernel.Dto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal UnitPrice { get; set; }
    }



    //public class CreateProductDto
    //{
    //    [Required]
    //    [MinLength(2)]
    //    [MaxLength(20)]
    //    public string Name { get; set; }

    //    [Required]
    //    [MinLength(2)]
    //    [MaxLength(20)]
    //    public string Desc { get; set; }


    //    [Range(0.01, double.MaxValue)]
    //    public decimal UnitPrice { get; set; }
    //}
}

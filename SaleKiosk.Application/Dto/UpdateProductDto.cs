using System.ComponentModel.DataAnnotations;

namespace SaleKiosk.SharedKernel.Dto
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal UnitPrice { get; set; }
    }

    //public class UpdateProductDto
    //{
    //    public int Id { get; set; }

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

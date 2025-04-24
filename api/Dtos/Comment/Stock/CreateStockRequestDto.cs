using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage ="symbol must be less than 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage ="company name must be less than 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,1000000000000, ErrorMessage ="value not in range")]
        public decimal Purchase{ get; set; }

        [Required]
        [Range(0.001, 100, ErrorMessage ="value not in range")]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "indestry must be less than 10 characters")]
        public string Indestry { get; set; } = string.Empty;

        [Required]
        [Range(1, 5000000000000, ErrorMessage ="value not in range")]
        public long MarketCap { get; set; }
    }
}
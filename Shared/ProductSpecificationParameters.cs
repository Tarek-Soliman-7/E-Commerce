using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationParameters
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public ProductSortingOptions Sort { get; set; }
        public string? Search { get; set; }

    }
}

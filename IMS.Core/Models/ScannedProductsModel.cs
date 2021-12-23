using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Dtos
{
  public  class ScannedProductsModel
    {

        //public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ItemsCount { get; set; }

        public virtual ICollection<ItemScannedModel> Items { get; set; }
    }
}

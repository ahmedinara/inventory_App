using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class User
    {
        public User()
        {
            CustmerCreatedByNavigations = new HashSet<Custmer>();
            CustmerUpdatedByNavigations = new HashSet<Custmer>();
            ProductMasterCreatedByNavigations = new HashSet<ProductMaster>();
            ProductMasterLastUpdateByNavigations = new HashSet<ProductMaster>();
            RfIdScannedProducts = new HashSet<RfIdScannedProduct>();
            SupplierCreatedByNavigations = new HashSet<Supplier>();
            SupplierUpdatedByNavigations = new HashSet<Supplier>();
            TransferInCreatedByNavigations = new HashSet<TransferIn>();
            TransferInDeletedByNavigations = new HashSet<TransferIn>();
            TransferInUpdateByNavigations = new HashSet<TransferIn>();
            TransferOutCreatedByNavigations = new HashSet<TransferOut>();
            TransferOutDeletedByNavigations = new HashSet<TransferOut>();
            TransferOutUpdateByNavigations = new HashSet<TransferOut>();
        }

        public int Id { get; set; }
        [DisplayName("أسم العميل")]
        [Required]

        public string FristName { get; set; }
        [DisplayName("أسم الاب")]
        [Required]

        public string LastName { get; set; }
        [DisplayName("رقم الهاتف")]
        [Required]
        public string MobileNo { get; set; }
       
        [DisplayName("البريد الالكتروني")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("كلمة السر")]
        public string Password { get; set; }

        public int? RoleId { get; set; }
        [DisplayName("مستخدم")]

        public int? CreatedBy { get; set; }
        [DisplayName("تاريخ الانشاء")]
        public DateTime CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [DisplayName("مفعل")]

        public bool IsActive { get; set; }
        [DisplayName("الشركه")]

        public int CompanyId { get; set; }
        public byte[] PasswordSalt { get; set; }
        [DisplayName("الشركه")]

        public virtual Company Company { get; set; }
        public virtual ICollection<Custmer> CustmerCreatedByNavigations { get; set; }
        public virtual ICollection<Custmer> CustmerUpdatedByNavigations { get; set; }
        public virtual ICollection<ProductMaster> ProductMasterCreatedByNavigations { get; set; }
        public virtual ICollection<ProductMaster> ProductMasterLastUpdateByNavigations { get; set; }
        public virtual ICollection<RfIdScannedProduct> RfIdScannedProducts { get; set; }
        public virtual ICollection<Supplier> SupplierCreatedByNavigations { get; set; }
        public virtual ICollection<Supplier> SupplierUpdatedByNavigations { get; set; }
        public virtual ICollection<TransferIn> TransferInCreatedByNavigations { get; set; }
        public virtual ICollection<TransferIn> TransferInDeletedByNavigations { get; set; }
        public virtual ICollection<TransferIn> TransferInUpdateByNavigations { get; set; }
        public virtual ICollection<TransferOut> TransferOutCreatedByNavigations { get; set; }
        public virtual ICollection<TransferOut> TransferOutDeletedByNavigations { get; set; }
        public virtual ICollection<TransferOut> TransferOutUpdateByNavigations { get; set; }
    }
}

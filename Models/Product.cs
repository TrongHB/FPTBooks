namespace FPTBookS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Imagas { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string Descriptions { get; set; }

        public int? CategoryID { get; set; }

        public int? AuthorID { get; set; }

        public int? PublishID { get; set; }

        [StringLength(1)]
        public string PhotoString { get; set; }

        [StringLength(1)]
        public string PhotoExtension { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Publisher Publisher { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public HttpPostedFileBase myfile
        {
            get; set;
        }
    }
    }

namespace FPTBookS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillID { get; set; }

        public DateTime BillDate { get; set; }

        [Required]
        [StringLength(255)]
        public string BillCustomer { get; set; }

        [Required]
        [StringLength(255)]
        public string BillAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string BillPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}

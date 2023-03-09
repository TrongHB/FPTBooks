namespace FPTBookS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter FirstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter LastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter Birthday")]
        public Nullable<System.DateTime> Birthday { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(100)]
        public string Address { get; set; }
        public Nullable<int> Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}

namespace Moedel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}

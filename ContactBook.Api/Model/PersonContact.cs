using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Api.Model
{
    public class PersonContact
    { 
        [Key]
        public int ContactId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string PersonName { get; set;}
        [Column(TypeName="nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string MobileNo { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ExtraMobileNo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }

    }
}

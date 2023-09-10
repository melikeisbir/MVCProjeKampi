using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category //access modify türü public
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //durumu aktif pasif yapmak için 

        public ICollection<Heading> Headings { get; set; } //bire çok ilişki  category sınıfında icollection adında property oluşturduk bu heading sınıfyla ilişkili olacak
    }
}

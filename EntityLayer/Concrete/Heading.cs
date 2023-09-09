using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        public int HeadingID { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public int CategoryID { get; set; } //category sınıfında 
        public virtual Category Category { get; set; } //category sınıfından category adında değer alıyoruz

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}

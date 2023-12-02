using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests.Request
{
    public class ReviewRequest
    {
        public Guid? Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid MasseurId { get; set; }
        public int Mark {  get; set; }
        public string Comment { get; set; }
    }
}

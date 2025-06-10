using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyForm.Entities
{
    public class SupplierOwnerRelationship
    {
        [Key]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public RelationshipStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}

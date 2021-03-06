//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuctionOnline.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auction()
        {
            this.AuctionStatus = new HashSet<AuctionStatu>();
        }
    
        public int AuctionID { get; set; }
        public int AccountID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal StartPrice { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Nullable<int> PermitID { get; set; }
        public bool Status { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuctionStatu> AuctionStatus { get; set; }
    }
}

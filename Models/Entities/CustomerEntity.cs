using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    [Table("customers")]
    public class CustomerEntity
    {
            
        [Column(name: "id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column(name: "username")]
        public string Username { get; set; }
        
        [Column(name: "email")]
        public string Email { get; set; }
        
        [Column(name: "password")]
        public string Password { get; set; }
        
        [Column(name: "shipping_address")]
        public string ShippingAddress { get; set; }
        
        [Column(name: "contact_details")]
        public string ContactDetails { get; set; }
        
        [Column(name: "preferences")]
        public string Preferences { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
        
    }
}
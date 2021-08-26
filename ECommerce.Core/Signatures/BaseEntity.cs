using System;

namespace ECommerce.Core.Signatures
{
    public class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
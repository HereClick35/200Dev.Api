using System;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class EntityBase
    {   
        public int Id { get; protected set; }
        public DateTime CreateBy { get; protected set; }
        public DateTime? ModifiedBy { get; protected set; }
        public int CreateUserId { get; protected set; }        
        public int ModifiedUserId { get; protected set; }
        //public string Token { get ; protected set; }
    }
}

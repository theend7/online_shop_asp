using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public bool isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool isActive { get; set; }
    }
}

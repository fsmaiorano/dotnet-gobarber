using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoBarber.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        private DateTime? _createdAt;
        [Column("created_at")]
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

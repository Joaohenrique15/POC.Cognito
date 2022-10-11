﻿using System;

namespace POC.Cognito.Core.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public override bool Equals(object obj)
        {
            EntityBase other = obj as EntityBase;

            if (other == null || this.GetType() != other.GetType())
            {
                return false;
            }

            return other.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

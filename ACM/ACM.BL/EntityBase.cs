using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public abstract class EntityBase
    {
        public bool isNew { get; private set; }
        public bool HasChanges { get; set; }
        public EntityStateOption EntityState { get; set; }

        public bool isValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();
    }
}

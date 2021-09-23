using System;

namespace BuiltCode.Domain.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}

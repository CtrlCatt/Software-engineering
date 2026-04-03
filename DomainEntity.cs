using System;

namespace ConsoleApp1
{
    public abstract class DomainEntity
    {
        public Guid Id { get; protected set; }

        protected DomainEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
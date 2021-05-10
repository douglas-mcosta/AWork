using AWork.Core.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWork.Core.DomainObjects
{
    //Entidade Base 
    public abstract class Entity
    {
        public Guid Id { get; set; }
        [NotMapped]
        private List<Event> _notidication;
        [NotMapped]
        public IReadOnlyCollection<Event> Notification => _notidication?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void AddEvent(Event evento)
        {
            _notidication = _notidication ?? new List<Event>();
            _notidication.Add(evento);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notidication?.Remove(eventItem);
        }

        public void ClearEvent()
        {
            _notidication?.Clear();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

    }
}
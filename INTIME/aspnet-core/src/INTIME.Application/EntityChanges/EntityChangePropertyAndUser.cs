using Abp.EntityHistory;
using INTIME.Authorization.Users;
using System.Collections.Generic;

namespace INTIME.EntityChanges
{
    public class EntityChangePropertyAndUser
    {
        public EntityChange EntityChange { get; set; }
        public List<EntityPropertyChange> PropertyChanges { get; set; }
        public User User { get; set; }
    }
}

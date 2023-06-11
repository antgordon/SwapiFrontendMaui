using MauiApp1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class EntityIdentifier
    {   
        public EntityType EntityType { get; }
        public string EntityId { get; }

        public EntityIdentifier(EntityType entityType, string entityId)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}

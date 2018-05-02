using System;
using System.Collections.Generic;
using System.Linq;

namespace LLECS
{
    public class Context
    {
        private int IdInc { get; set; } = 1;

        // TODO: Improve grouping
        public Dictionary<int, Entity> Entities { get; private set; } = new Dictionary<int, Entity>();
        // TODO: System Grouping - Feature / Dispatcher
        public List<ISystem> Systems { get; private set; } = new List<ISystem>();
        // Entity
        public int SpawnEntity(Entity entity)
        {
            var entityId = IdInc++;
            entity.Id = entityId;
            Entities[entityId] = entity;
            return entityId;
        }

        public void Update()
        {
            foreach (var system in Systems)
            {
                system.Update();
            }
        }
    }
}

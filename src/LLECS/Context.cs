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
        public Entity SpawnEntity()
        {
            var e = new Entity();
            e.Id = IdInc++;
            Entities[e.Id] = e;
            return e;
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

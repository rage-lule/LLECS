using System;
using System.Collections.Generic;
using LLECS.Collections;

namespace LLECS
{
    public class Entity
    {
        public int Id { get; set; }
        public TypedDictionary<IComponent> Components { get; private set; } = new TypedDictionary<IComponent>(new Dictionary<Type, IComponent>());
    }
}

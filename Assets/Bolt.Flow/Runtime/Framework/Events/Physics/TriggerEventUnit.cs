using Ludiq;
using UnityEngine;

namespace Bolt
{
    [UnitCategory("Events/Physics")]
    public abstract class TriggerEventUnit : GameObjectEventUnit<Collider>
    {
        /// <summary>
        /// The other collider involved in the collision.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput collider { get; private set; }

        protected override void Definition()
        {
            base.Definition();

            collider = ValueOutput<Collider>(nameof(collider));
        }

        protected override void AssignArguments(Flow flow, Collider other)
        {
            flow.SetValue(collider, other);
        }
    }
}
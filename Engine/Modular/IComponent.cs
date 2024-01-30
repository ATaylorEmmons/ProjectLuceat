

namespace Engine.Modular
{
    /// <summary>
    /// Interface for Component types to be attached to an entity.
    /// </summary>
    public abstract class IComponent
    {
        /// <summary>
        /// Called Every Frame by the entity that this is attached to.
        /// </summary>
        /// <param name="delta"> In milliseconds the change in time from the last frame to this frame.</param>

        public Entity? Owner { set; get; }
        public abstract string Type { get; }
        public string Name { get; set; } = "DefaultComponentName";

        public abstract void Initilize();
        public abstract void Process(float deltaTime);

    }
}
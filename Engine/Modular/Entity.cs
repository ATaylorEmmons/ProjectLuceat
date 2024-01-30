
using Microsoft.Xna.Framework;


namespace Engine.Modular
{

    public class Entity : Transform
    {
        string Name { get; set; }
        public Entity? Parent { get; set; }

        List<IComponent> components;
        List<Entity> children;


        public bool InheritPosition { get; set; }  = true;
        public bool InheritRotation { get; set; } = false;
        public bool InheritScale { get; set; } = true;  


        public Entity()
        {
            Name = "Root";
            Parent = null;
            Position = new Vector2(0.0f, 0.0f);
            this.children = new List<Entity>();
            this.components = new List<IComponent>();
        }

        public Entity(string name)
        {
            this.Name = name;
            this.children = new List<Entity>();
            this.components = new List<IComponent>();

        }

        public Entity(string name, Vector2 pos, Vector2 scale)
        { 
            this.Name = name;
            this.Position = pos;
            this.Scale = scale;
            this.children = new List<Entity>();
            this.components = new List<IComponent>();

        }

        public void Initilize()
        {
            foreach (var child in this.children)
            {
                child.Initilize();
            }

            foreach (IComponent component in this.components)
            {
                component.Initilize();
            }
        }

        public void AddComponent(IComponent component)
        {
            component.Owner = this;
            this.components.Add(component);
        }

        public IComponent? GetFirstComponentOfType(string type)
        {
            foreach (IComponent component in this.components)
            {
                if (component.Type == type) { 
                    return component;
                }
            }

            return null;
        }

        public IComponent? GetComponentByName(string name)
        {
            /* TODO:
             *      This could be made faster(but take more memory)
             *      by relating name to a the index in the components
             *      array via a HashMap
             */
            foreach (IComponent component in this.components)
            {
                if (component.Name == name)
                {
                    return component;
                }
            }

            return null;
        }



        public int Count()
        {
            return this.children.Count();
        }

        public void AddChild(Entity child)
        {
            child.Parent = this;
            this.children.Add(child);

            child.WorldPosition = child.Position + this.Position;

        }

        public Entity GetChild(int index)
        {
            return this.children[index];
        }

        public Entity? GetChildByName(string name)
        {

            foreach (Entity child in this.children)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }

            return null;
        }

        public void Update(float deltaTime)
        {



            foreach (Entity child in this.children)
            {

                //TODO: Dirty flag to only update positions when needed
                if(InheritPosition)
                {
                    child.WorldPosition = child.Position + this.Position;
                }

                if(InheritRotation)
                {
                    child.Rotation += Rotation;
                }

                child.Update(deltaTime);
            }

            foreach (IComponent component in this.components)
            {
                component.Process(deltaTime);
            }

        }

    }
}
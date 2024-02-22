# ProjectLuceat

A game engine with C# and MonoGame [https://monogame.net/].

Uses Scenes and an Entity Component System to manage game objects. 

# Brief reminder on building scenes
1) Scenes contain some default objects (A camera, particle system, sprite system, etc). 
2) A scene also contains a Root node which is to be the parent for all other entities.
3) Entities contain components to modify behavior.

# Development Reminders
 - Any component or system that could easily be scene in ALL graphical applications need to be developed in the Engine project.
 - Any component that is specific (Lookin' at you ProjectLuceat.GameComponents.CircleExhaustEmitter) should go in the "ProjectLuceat" project.

# Todo's
 - Immediate Mode UI (For Reference: https://caseymuratori.com/blog_0001) [Implement on GPU, outside of SpriteBatch?]
 - Physics collision phases (broad phase will likely be a quad tree)
 - Frustrum culling within the SpriteSystem
 - Input Configuration file [Command Pattern: https://gameprogrammingpatterns.com/command.html]

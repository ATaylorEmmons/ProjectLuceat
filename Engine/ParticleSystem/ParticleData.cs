
using Microsoft.Xna.Framework;


namespace Engine.ParticleSystem
{
    public class ParticleData
    {

        public string TextureOffsetName = "Default";
        public Vector2 Normal = new Vector2();

        public float theta = 0.0f;

        public float lifespan = 2f;
        public float lifeSpanRatio = 1.0f;

        public float startScale = 1f;
        public float endScale = 1f;

        public Color startColor = Color.Black;
        public Color endColor = Color.White;

        public float startOpacity = 1f;
        public float endOpacity = 1f;

        public ParticleData() { }

        public ParticleData(ParticleData template) { 
            TextureOffsetName = template.TextureOffsetName;
            Normal = template.Normal;
            theta = template.theta;


            lifespan = template.lifespan;
            startScale = template.startScale;
            endScale = template.endScale;

            startColor = template.startColor;
            endColor = template.endColor;
            startOpacity = template.startOpacity;
            endOpacity = template.endOpacity;


        
        }

    }
}

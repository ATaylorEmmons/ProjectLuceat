

namespace Engine.ParticleSystem
{
    public class ParticleEmitterData
    {
        public string name = "DefaultName";
        public string pathName = "DefaultPathName";

        public float angleVariance = 0f;
        public float minLifeSpan = 0f;
        public float maxLifeSpan = 0f;

        public float minSpeed = 1f;
        public float maxSpeed = 1f;

        public bool startImmediatly = true;


        public float emitInterval = .05f;
        public int emitCount = 10;



    }
}

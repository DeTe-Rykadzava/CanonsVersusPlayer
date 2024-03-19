namespace Input
{
    public abstract class AMouseInput
    {
        public float MouseX { get; protected set; }
        public float MouseY { get; protected set; }
        public float MouseWheel { get; protected set; }

        public abstract void Update();
    }
}
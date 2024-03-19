namespace Input
{
    public abstract class AInput
    {
        public float LeftRight { get; protected set; }
        public float ForwardBack { get; protected set; }
        public bool Jump { get; protected set; }
        public float Sprint { get; protected set; }
        
        public abstract void Update();
    }
}
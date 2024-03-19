namespace Input
{
    public static class InputManager
    {
        private static AInput _input = null;
        public static AInput Input => _input ??= new KeyboardInput();
        
        private static AMouseInput _mouseInput = null;
        
        public static AMouseInput MouseInput => _mouseInput ??= new MouseInput();
        
    }
}

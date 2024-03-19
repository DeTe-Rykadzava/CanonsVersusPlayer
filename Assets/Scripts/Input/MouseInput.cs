namespace Input
{
    public class MouseInput : AMouseInput
    {
        public override void Update()
        {
            MouseX = UnityEngine.Input.GetAxis("Mouse X");
            MouseY = UnityEngine.Input.GetAxis("Mouse Y");
            MouseWheel = UnityEngine.Input.GetAxis("Mouse ScrollWheel");
        }
    }
}
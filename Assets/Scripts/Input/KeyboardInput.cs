using System;
using UnityEngine;

namespace Input
{
    public class KeyboardInput : AInput
    {
        public override void Update()
        {
            LeftRight = UnityEngine.Input.GetAxisRaw("Horizontal");
            ForwardBack = UnityEngine.Input.GetAxisRaw("Vertical");
            Jump = UnityEngine.Input.GetAxis("Jump") != 0;
            Sprint = Convert.ToSingle(UnityEngine.Input.GetKey(KeyCode.LeftShift));
        }
    }
}
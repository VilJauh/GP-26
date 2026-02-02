using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace AE9730
{
    public class SpinObject : MonoBehaviour
    {

        private Key activationKey = Key.V;

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current[activationKey].isPressed)
                transform.Rotate(1.0f, 0f, 0f);
        }
    }
}
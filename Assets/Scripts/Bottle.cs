using UnityEngine;
using UnityEngine.InputSystem;

namespace AE9730
{
    public class Bottle : MonoBehaviour
    {
        public Material bottleMaterial;
        public string bottleContents;
        [Range(0.0f, 1.0f)]
        public float liquidAmount;

        public Key capOffKey = Key.Y;
        public Key fillBottle = Key.U;

        private float minimumLiquidCapacity = 0.0f;
        private float maximumLiquidCapacity = 1.0f;

        public bool isCapOn = true;

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current[capOffKey].wasPressedThisFrame)
            {
                switch (isCapOn)
                {
                    case true:
                        Debug.Log("Cap is off");
                        isCapOn = false;
                        break;
                    case false:
                        Debug.Log("Cap is on");
                        isCapOn = true;
                        break;
                }
            }
            if (Keyboard.current[fillBottle].wasPressedThisFrame)
            {
                liquidAmount = maximumLiquidCapacity;
                Debug.Log("Bottle is filled");
                switch (isCapOn)
                {
                    case true:
                        Debug.Log("Can't fill while cap is closed");
                        break;
                    case false:
                        Debug.Log("Bottle is filled");
                        break;
                }
            }
        }

        public void ChangeLiquidAmount(float changeAmount)
        {
            //TODO: Change the amount of liquid and safeguard against going below or over the capacity of the bottle IF cap is off
            if (isCapOn == false && liquidAmount > minimumLiquidCapacity) { 
                liquidAmount -= changeAmount;
                Debug.Log($"Liquid amount changed by -{changeAmount}");
                Debug.Log($"Liquid amount in bottle {liquidAmount}");
            }
            if (isCapOn == true)
            {
                Debug.Log("Take off the cap");
            }
        }
    } 
}

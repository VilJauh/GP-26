using UnityEngine;

namespace AE9730
{
    public class Bottle : MonoBehaviour
    {
        public Material bottleMaterial;
        public string bottleContents;
        [Range(0.0f,1.0f)]
        public float liquidAmount;
        public bool isCapOn = true;

        private float minimumLiquidAmount = 0.0f;
        private float maximumLiquidAmount = 1.0f;

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeLiquidAmount(float changeAmount)
        {
            // TODOchange amount of liquid and safeguard against going below or over the capacity of the bottle

        }
    } 
}

using AE9730;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cup : MonoBehaviour
{
	public Bottle bottleToInteractWith;
	[Range(-3.0f, 3.0f)]
	public float fillValue;
    public Key activationKey = Key.T;

    // Update is called once per frame
    void Update()
	{
		if (Keyboard.current[activationKey].wasPressedThisFrame)
		{
			ChangeLiquidAmountOfTargetContainer();
		}

	}

	private void ChangeLiquidAmountOfTargetContainer()
	{
		bottleToInteractWith.ChangeLiquidAmount(fillValue);
	}

	//private void OnCollisionEnter(Collision collision)
	//{

	//}
}

using System;
using UnityEngine;
using Random = UnityEngine.Random; //System.Random

namespace AA0000
{
	//Based on https://www.youtube.com/watch?v=lM4SsNSRU0w&t=1015s&ab_channel=StephenHubbard

	[RequireComponent(typeof(Rigidbody))]
	public class Dice : MonoBehaviour
	{
		#region Variables
		public Action<float> OnDiceStopped;

		[Tooltip("Dice Sides must be named with the number value of the side")]
		[SerializeField] Transform[] diceSides;
		// [SerializeField] List<Transform> diceSidesList;
		[SerializeField] private float force = 5.0f;
		[SerializeField] private float forceVariation = 1.0f;
		[SerializeField] private float torque = 5.0f;
		[SerializeField] private float torqueVariation = 1.0f;

		Rigidbody diceRigidbody;
		bool wasRolled = false;
		#endregion

		private void Awake()
		{
			diceRigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			if (diceRigidbody.IsSleeping() && wasRolled)
			{
				float result = GetSideFacingTowardDirection();
				OnDiceStopped.Invoke(result);
			}
		}

		public void RollObject()
		{
			float randomForce = Random.Range(force - forceVariation, force + forceVariation);
			Vector3 rollForce = new Vector3(0f, randomForce, 0f);
			float randomTorque = Random.Range(torque - torqueVariation, torque + torqueVariation);
			float randomX = Random.Range(-1f, 1f);
			float randomY = Random.Range(-1f, 1f);
			float randomZ = Random.Range(-1f, 1f);
			Vector3 rollTorque = new Vector3(randomX, randomY, randomZ) * randomTorque;

			diceRigidbody.AddForce(rollForce, ForceMode.Impulse);
			diceRigidbody.AddTorque(rollTorque, ForceMode.Impulse);

			wasRolled = true;
		}

		public float GetSideFacingTowardDirection(Vector3? direction = null)
		{
			if (direction == null)
			{
				direction = Vector3.up;
			}

			Transform upSide = null;
			float maxDot = -1;

			foreach (Transform side in diceSides)
			{
				float dot = Vector3.Dot(side.up, direction.Value);

				if (!(dot > maxDot)) continue;
				maxDot = dot;
				upSide = side;
			}

			wasRolled = false;

			if (upSide != null)
			{
				return float.Parse(upSide.name);
			}
			else
			{
				return 0f;
			}

		}

	}

}
using AA0000;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;


namespace AA0000
{
	//Based on https://www.youtube.com/watch?v=lM4SsNSRU0w&t=1015s&ab_channel=StephenHubbard

	public class DiceManager : MonoBehaviour
	{
		[SerializeField] Dice[] diceToRoll;
		public Key activationKey = Key.T;

		private float totalSum = 0;
		bool isAnyDiceRolling = false;
		int diceStillRolling = 0;

		private void Start()
		{
			foreach (Dice dice in diceToRoll)
			{
				dice.OnDiceStopped += OnDieStopped;
			}
		}

		private void Update()
		{
			if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current[activationKey].wasPressedThisFrame)// && !isAnyDiceRolling)
			{
				RollAllDice();
			}
		}

		void RollAllDice()
		{
			isAnyDiceRolling = true;
			diceStillRolling = diceToRoll.Length;
			totalSum = 0;

			foreach (Dice dice in diceToRoll)
			{
				dice.RollObject();
			}
		}

		void OnDieStopped(float result)
		{
			totalSum += result;
			diceStillRolling--;

			if (diceStillRolling == 0)
			{
				isAnyDiceRolling = false;
				Debug.Log($"Sum: {totalSum}");
			}
		}

		private void OnDestroy()
		{
			foreach (Dice dice in diceToRoll)
			{
				dice.OnDiceStopped -= OnDieStopped;
			}
		}
	}

}
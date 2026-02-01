using UnityEngine;
using Unity.FPS.Game;

namespace AA0000
{
	public class DamageableShootingTarget : Damageable
	{
		public Renderer objectRenderer;
		public Color swapColor = Color.green;
		public Color originalColor;
		public bool colorSwapped = false;

		internal virtual void Start()
		{
			objectRenderer = GetComponent<Renderer>();
			originalColor = objectRenderer.material.color;
		}

		public override void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
		{
			base.InflictDamage(damage, isExplosionDamage, damageSource);

			SwapColor();

		}

		public void SwapColor()
		{
			if (!colorSwapped)
			{
				objectRenderer.material.color = swapColor;
			}
			else 
			{
				objectRenderer.material.color = originalColor;
			}
			colorSwapped = !colorSwapped;
		}

		private void OnDisable()
		{
			objectRenderer.material.color = originalColor;
		}
	}
}

using UnityEngine;

public class Character : MonoBehaviour
{
    protected int hpAmount = 100;
    protected int maxDamage = 5;
    protected virtual void TakeDamage(int damage) 
    {
        Debug.Log("Damage taken: " + damage);
    }
}

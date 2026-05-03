using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private TMPro.TextMeshProUGUI hp;
    void Start()
    {
        hp.text = "HP: " + hpAmount.ToString();
    }

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        hpAmount -= damage;
        hp.text = "HP: " + hpAmount.ToString();
    }
    public void DealDamage() 
    {
        int damage = Random.Range(0, maxDamage);
        TakeDamage(damage);
    }
}

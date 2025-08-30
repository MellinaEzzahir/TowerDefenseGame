using UnityEngine;
using System.Collections;

public class TowerHealth : MonoBehaviour
{
    public TowerUI towerUI;
    public float maxHealth;
    private float health;
    //private bool poisoning = false;
    //private bool healing = false;

    public global::System.Single Health { get => health; set { health = value; HealthChanged(); } }

    public void Start()
    {
        maxHealth = 100;
        Health = maxHealth;
    }
    private void OnMouseDown()
    {
        TakeDamage(20);
    }

    private void HealthChanged()
    {
        if (Health == maxHealth)
        {
            towerUI.HideBar();
        }
        else if (Health <= 0 )
        {
            TowerDeath();
        }
        else
        {
            towerUI.ShowBar();
            towerUI.SetHealth();
        }
    }

    private void TowerDeath()
    {

    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        towerUI.PlaySound("Hit");
    }

    public IEnumerator PoisonEffect(float damagePerTime, float durationOfWait, int rounds)
    {
        // poisoning = true;
        towerUI.PoisonHealthEffect(true);
        towerUI.ShakeTowerHealth();
        for (int i = rounds; i > 0; i--)
        {
            TakeDamage(damagePerTime);
            yield return new WaitForSeconds(durationOfWait);
            towerUI.ShakeTowerHealth();
        }
        towerUI.ShakeTowerHealth();
        towerUI.PoisonHealthEffect(false);
    }

    public IEnumerator HealthEffect(float healthAdded)
    {
        towerUI.HealthPotion(true);
        towerUI.PlaySound("Recharge");
        float healthAddedSoFar = 0;
        while (Health < maxHealth && healthAddedSoFar < healthAdded)
        {
            healthAddedSoFar += 1;
            Health += 1;
            yield return new WaitForSeconds((float)0.03);
        }
        towerUI.ShakeTowerHealth();
        Debug.Log(Health);
        towerUI.HealthPotion(false);
    }
}

using UnityEngine;
using System.Collections;

public class TowerHealth : MonoBehaviour
{
    public TowerUI towerUI;
    public TowerBase towerBase;
    public float maxHealth;
    private float health;
    private bool poisoning = false;
    private bool healing = false;

    public global::System.Single Health { get => health; set { health = value; HealthChanged(); } }

    public void Start()
    {
        maxHealth = towerBase.maxHealth;
        Health = maxHealth;
    }
    private void OnMouseDown()
    {
        TakeDamage(20);
    }

    private void HealthChanged()
    {
        if (Health == maxHealth && poisoning == false)
        {
            towerUI.HideBar();
        }
        else if (Health <= 0)
        {
            TowerDeath();
        }
        else
        {
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
        poisoning = true;
        UpdateHealthVariable();
        towerUI.ShakeTowerHealth();
        for (int i = rounds; i > 0; i--)
        {
            TakeDamage(damagePerTime);
            yield return new WaitForSeconds(durationOfWait);
            towerUI.ShakeTowerHealth();
        }
        towerUI.ShakeTowerHealth();
        poisoning = false;
        UpdateHealthVariable();
        towerUI.SetHealth();
    }

    public IEnumerator HealthEffect(float healthAdded)
    {
        healing = true;
        UpdateHealthVariable();
        towerUI.PlaySound("Recharge");
        float healthAddedSoFar = 0;
        while (Health < maxHealth && healthAddedSoFar < healthAdded)
        {
            healthAddedSoFar += 1;
            Health += 1;
            yield return new WaitForSeconds((float)0.03);
        }
        towerUI.ShakeTowerHealth();
        healing = false;
        UpdateHealthVariable();
    }

    public void UpdateHealthVariable()
    {
        if (poisoning == false && healing == false)
        {
            towerUI.ChangeSprite(1);
            towerUI.ChangeGradient(1);
        }
        else if (poisoning == true && healing == false)
        {
            towerUI.ChangeSprite(2);
            towerUI.ChangeGradient(3);
        }
        else if (poisoning == false && healing == true)
        {
            towerUI.ChangeSprite(3);
            towerUI.ChangeGradient(2);
        }
        else if (poisoning == true && healing == true)
        {
            towerUI.ChangeSprite(4);
            towerUI.ChangeGradient(4);
        }
    }
}
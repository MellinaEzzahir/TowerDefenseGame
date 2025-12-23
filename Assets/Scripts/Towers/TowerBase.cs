using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public TowerConfigSO TowerConfig;
    public float maxHealth;
    public float pearlCost;

    public void Awake()
    {
        maxHealth = TowerConfig.health;
        pearlCost = TowerConfig.pearlCost;
    }
}
using UnityEngine;

public class PoisonTest : MonoBehaviour
{
    public TowerHealth TowerHealth;

    public void PoisonTestFunc()
    {
        StartCoroutine(TowerHealth.PoisonEffect(10, 2, 5));
    }

    public void HealthTestFunc()
    {
        StartCoroutine(TowerHealth.HealthEffect(50));
    }
}

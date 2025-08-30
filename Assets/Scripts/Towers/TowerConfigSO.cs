using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfigSO", menuName = "Scriptable Objects/Tower Configuration")]
public class TowerConfigSO : ScriptableObject
{
    public string towerName;
    public GameObject towerPrefab;
    public float slotSize;
    public float pearlCost;
    public float health;
}

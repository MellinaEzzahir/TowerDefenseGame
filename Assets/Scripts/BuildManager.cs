using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private TowerType[] towers;
    private int selectedTower = 0;

    public void Awake()  
    {
        main = this; 
    }

    public TowerType GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) 
    {
        selectedTower = _selectedTower;  
    }
}
   
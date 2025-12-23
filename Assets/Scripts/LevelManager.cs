using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;

    public int currency;

    private void Awake(){
        main = this;
    }

    private void Start(){
        currency = 100000;
    }

    public void IncreaseCurrency(int amount){
        currency += amount;
    }

    public bool SpendCurrency(int amount){
        if (amount <= currency){
            currency -= amount;
            return true;
        }else{
            Debug.Log("Not enough currency");
            return false;
        }
    }
}

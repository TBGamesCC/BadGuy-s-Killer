using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moeny : MonoBehaviour
{
    private int StartMoney;
    public int CurrentMoney;
    [SerializeField] int MoneyToADD;
    [SerializeField] Text TextMoney;
    void Start()
    {
        StartMoney = 0;
        CurrentMoney = StartMoney;
        GameEvents.ThiefDie += AddMoney;
    }
    void OnDestroy()
    {
        GameEvents.ThiefDie -= AddMoney;
    }
    private void AddMoney(GameEvents.ThifeData thifdata)
    {
        if (thifdata.IsDie)
        {
            CurrentMoney += MoneyToADD;
        }
    }
    void Update()
    {
        TextMoney.text = "Money : " + CurrentMoney;
        
    }
}

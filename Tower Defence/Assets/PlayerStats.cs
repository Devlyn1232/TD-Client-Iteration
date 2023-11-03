using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Money;//:)
    public Text MoneyUI;

    // Update is called once per frame
    public void GainMoney(int AddedMoney)
    {
        Money += AddedMoney;
        MoneyUI.text = Money.ToString();
    }
    
}

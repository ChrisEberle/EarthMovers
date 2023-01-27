using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour, IDataPersistence
{
    private int money = 0;

    private TextMeshProUGUI moneyText;

    private void Awake() 
    {
        moneyText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData data) 
    {
        this.money = data.money;
    }

    public void SaveData(GameData data) 
    {
        data.money = this.money;
    }

    private void Update() 
    {
        moneyText.text = "" + money;

        if ( Input.GetKey(KeyCode.Space) )
        {
            this.money += 100;
        }
    }
}
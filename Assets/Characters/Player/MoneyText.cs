using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI text;
    
    private int money;

    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.money = data.money;
    }

    public void SaveData(ref GameData data)
    {
        data.money = this.money;
    }


    void Update()
    {
        // prints money onto screen
         string m = money.ToString();
         text.text = m;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour, IDataPersistence
{
    public GameData gd;
    public TextMeshProUGUI text;
    
    private int moneys;

    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.moneys = data.money;
    }

    public void SaveData(ref GameData data)
    {
        data.money = this.moneys;
    }


    void Update()
    {
        moneys = gd.money;
        // prints money onto screen
         string m = moneys.ToString();
         text.text = m;
    }
}
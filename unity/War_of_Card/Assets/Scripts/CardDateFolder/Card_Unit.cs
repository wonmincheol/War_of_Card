using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Unit : MonoBehaviour
{
    GameObject data_Arr;
    Unit_Card card_date;
    // Start is called before the first frame update
    void Awake()
    {
        card_date = new Unit_Card();
        set_Date(1001);
        Debug.Log(this.card_date.card_Name);
    }

    public void set_Date(int id)
    {
        data_Arr = GameObject.Find("GameManager");
        card_date.card_Type = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Type;
        card_date.card_Name = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Name;
        card_date.card_Cost = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Cost;
        card_date.card_Sprite = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Sprite;
        card_date.card_Description = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Description;
        card_date.max_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.now_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.damage = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].damage;
    }
}

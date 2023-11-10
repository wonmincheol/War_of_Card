using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Object/CardData", order = int.MaxValue)]
[System.Serializable]
public class CardData : ScriptableObject
{
    public int card_ID;
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public List<string> now_Buff_String;
    public int max_HP;
    public int now_HP;
    public int damage;
    public Vector3[] move;
}
[System.Serializable]
public class ArrCardData
{
    public CardData[] dataList;
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Object/CardData", order = int.MaxValue)]
[System.Serializable]
public class CardData : ScriptableObject
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public int card_Range;
    public int max_HP;
    public int Damage;
}

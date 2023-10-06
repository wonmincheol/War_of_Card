using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Unit_Card
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public int card_Range;
    public int max_HP;
    public int Damage;
    public Unit_Card(Card_DataForm card)
    {
        this.card_Type = card.card_Type;
        this.card_Name = card.card_Name;
        this.card_Cost = card.card_Cost;
        this.card_Sprite = card.card_Sprite;
        this.card_Description = card.card_Description;
        this.card_Range = card.card_Range;
        this.max_HP = card.max_HP;
        this.Damage = card.Damage;
    }
}
public class Build_Card
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public int max_HP;
    public Build_Card(Card_DataForm card)
    {
        this.card_Type = card.card_Type;
        this.card_Name = card.card_Name;
        this.card_Cost = card.card_Cost;
        this.card_Sprite = card.card_Sprite;
        this.card_Description = card.card_Description;
        this.max_HP = card.max_HP;
    }
}
public class Magic_Card
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public Magic_Card(Card_DataForm card)
    {
        this.card_Type = card.card_Type;
        this.card_Name = card.card_Name;
        this.card_Cost = card.card_Cost;
        this.card_Sprite = card.card_Sprite;
        this.card_Description = card.card_Description;
    }
}
public class Commander_Card
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
    public int card_Range;
    public int max_HP;
    public int Damage;
    public Commander_Card(Card_DataForm card)
    {
        this.card_Type = card.card_Type;
        this.card_Name = card.card_Name;
        this.card_Cost = card.card_Cost;
        this.card_Sprite = card.card_Sprite;
        this.card_Description = card.card_Description;
        this.card_Range = card.card_Range;
        this.max_HP = card.max_HP;
        this.Damage = card.Damage;
    }
}
[System.Serializable]
public class Card_DataForm
{
    public char card_Type; //c, d, u ,m
    public string card_Name;
    public int card_Cost;
    public int card_Range;
    public Sprite card_Sprite;
    public string card_Description;
    public int max_HP;
    public int Damage;
}
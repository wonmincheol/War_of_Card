using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CardForm
{
    public char card_Type;
    public string card_Name;
    public int card_Cost;
    public Sprite card_Sprite;
    public string card_Description;
}
public class Unit_Card : CardForm
{
    public int card_Range;
    public int max_HP;
    public int now_HP;
    public int damage;
}
public class Build_Card : CardForm
{
    public int max_HP;
    public int now_HP;
}
public class Magic_Card : CardForm
{
   
}
public class Commander_Card : CardForm
{
    public int card_Range;
    public int max_HP;
    public int now_HP;
    public int damage;
}
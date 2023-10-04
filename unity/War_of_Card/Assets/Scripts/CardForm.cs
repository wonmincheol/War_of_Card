using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card_DataForm
{
    //public int card_ID;
    //public char card_Type;
    public string card_Name;
    public int card_Cost;
    //public int card_Range;
    //public Sprite card_Sprite;
    public string card_Description;
    public int max_HP;
    public int Damage;
   // public Card_DataForm(//int card_ID,
   //// char card_Type,
   // string card_Name,
   // int card_Cost,
   // //int card_Range,
   // //Sprite card_Sprite,
   // string card_Description,
   // int max_HP,
   // int Damage)
   // {
   //     //this.card_ID = card_ID;
   //     //this.card_Type = card_Type;
   //     this.card_Name = card_Name;
   //     this.card_Cost = card_Cost;
   //     //this.card_Range = card_Range;
   //     //this.card_Sprite = card_Sprite;
   //     this.card_Description = card_Description;
   //     this.max_HP = max_HP;
   //     this.Damage = Damage;
   // }
    public int Get_max_HP()
    {
        return max_HP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    [SerializeField] TMP_Text Cost_text;
    [SerializeField] TMP_Text Name_text;
    [SerializeField] SpriteRenderer image;
    [SerializeField] TMP_Text Description_text;
    [SerializeField] TMP_Text Damage_text;
    [SerializeField] TMP_Text Health_text;
    [SerializeField] TMP_Text Turn_text;

    [SerializeField] Sprite Card_Design;

    public CardData item;
    bool isFront; //앞 뒤 판단

    public void Setup(CardData item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;
        if(this.isFront)
        {
            image.sprite=this.item.card_Sprite;
            Name_text.text=this.item.card_Name;
            Description_text.text = this.item.card_Description;
        }
        else
        {
            
        }
    }
}
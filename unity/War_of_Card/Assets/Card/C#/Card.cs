using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer image;
    [SerializeField] TMP_Text cardname;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text damage;
    [SerializeField] TMP_Text time;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text cost;
   
    public CardData cardData;
    bool isFront;

    public void Setup(CardData cardData, bool isFront)
    {
        this.cardData = cardData;
        this.isFront = isFront;
        if(this.isFront )
        {
            image.sprite = this.cardData.card_Sprite;
            cardname.text = this.cardData.card_Name;
            if (this.cardData.card_Type == 'c')
            {//커멘더 카드 표시
                damage.text = this.cardData.damage.ToString();
                health.text = this.cardData.max_HP.ToString();

            }
            else if (this.cardData.card_Type == 'm')
            {//마법 카드 표시

            }
            else if (this.cardData.card_Type == 'p')
            {//건물 카드 표시

            }
            else 
            {//유닛 카드 표시

            }

        }
        else
        {// 카드의 축을 180도 회전 시켜서 뒷면을 표시 예정

        }
    }

}

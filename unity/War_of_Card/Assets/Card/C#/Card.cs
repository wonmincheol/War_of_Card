using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    [SerializeField] TMP_Text Health_text;
    [SerializeField] TMP_Text Damage_text;
    [SerializeField] TMP_Text Turn_text;
    [SerializeField] SpriteRenderer Commander_Card;
    [SerializeField] SpriteRenderer Magic_Card;
    [SerializeField] SpriteRenderer Place_Card;
    [SerializeField] SpriteRenderer Unit_Card;
    [SerializeField] TMP_Text Name_text;
    [SerializeField] TMP_Text Description_text;
    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    public CardData item;
    bool isFront; //앞 뒤 판단

}
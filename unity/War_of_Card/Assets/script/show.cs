using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{

    public static show instance;
    private List<car> allCards;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }
    void Start()
    {
        board board = FindAnyObjectByType<board>();
       allCards= board.GetCars();
        StartCoroutine("FlipallcardRoutine");
    }
    IEnumerator FlipallcardRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        FlipAllCards();
    }

   void FlipAllCards()
    {
        foreach(car card in allCards)
        {
            card.FlipCard();
        }
    }
}

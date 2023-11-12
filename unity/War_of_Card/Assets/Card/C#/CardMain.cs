using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public CardData[] items;
}
public class CardMain : MonoBehaviour
{
    [SerializeField] ItemSO itemso;
    [SerializeField] GameObject[] cardPrefab;
    List<CardData> cardsBuffer;
    public CardData PopItem()//카드 뽑을 때
    {//이미 무작위 된 상태이므로 위에서 부터 하나씩
        CardData card = cardsBuffer[0];
        cardsBuffer.RemoveAt(0);
        return card;
    }
    void SetupBuffer()
    {
        cardsBuffer = new List<CardData>(); //한 번만 사용하기 때문에
        for(int i = 0; i < itemso.items.Length; i++)//덱에 사용된 카드 종류 수 = itemso.items.Length
        {
            CardData card = itemso.items[i];
            for (int j = 0; j < card.card_Cost; j++)//Cost는 나중에 카드가 덱에 몇 장있는지로 설정
            {//덱 복제
                cardsBuffer.Add(cardsBuffer[i]);
            }
        }
        for(int i = 0;i < cardsBuffer.Count; i++)
        {//덱에서 무작위 출력 부분
            int rand = Random.Range(i, cardsBuffer.Count);
            CardData temp = cardsBuffer[i];
            cardsBuffer[i] = cardsBuffer[rand];
            cardsBuffer[rand] = temp;
        }
    }
    private void Start()
    {
        SetupBuffer();
    }
    public void Update()
    {
        print(PopItem().card_Name); //카드 뽑는 즉시
    }
    void AddCard()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dack : ScriptableObject
{//카드 데이터 배열로 상속
    public CardData[] items;
}
public class Card_Hand : MonoBehaviour
{   
    [SerializeField] Dack dack;
    List<CardData> itemBuffer;

   public CardData PopItem()
    {//카드 뽑은 후 버퍼에서 삭제
        CardData item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }
    void SetupItemBuffer()          
    {
        itemBuffer = new List<CardData>();
        //scene 변수 대신 버퍼 제작
        for(int i=0;i< dack.items.Length;i++)
        {
            CardData item = dack.items[i];
        }
        for(int i = 0; i < itemBuffer.Count; i++)
        {//카드 순서 랜덤
            int rand = Random.Range(i,itemBuffer.Count);
            CardData temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }
   void Start()
    {
        SetupItemBuffer();
    }
}

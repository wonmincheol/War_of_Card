using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSO : ScriptableObject
{//카드의 데이터 인덱스 배열화
    public CardData[] items;
}
public class Card_Hand : MonoBehaviour
{   
    public static Card_Hand Inst { get; private set; }
    void Awake() => Inst = this;
    [SerializeField] ItemSO itemSO;
    List<CardData> itemBuffer;
   /* public GameObject[] cardPrefab; // 카드 프리팹
    private float cardXOffset = 5.0f; // 각 카드의 X 축 간격
    private float nextCardX = 0.0f; // 다음 카드의 X 위치
    private float cardZOffset = 0.5f; // 각 카드의 Z 축 간격
    private float nextCardZ = 0.0f; // 다음 카드의 Z 위치
    int draw_count = 0;
    private void Update()
    {
        // 특정 키 (예: 'C' 키)를 눌렀을 때 카드를 생성합니다.
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (draw_count <= 5)
            {
                SpawnCard();
                draw_count++;
            }
        }
    }
    
    void SpawnCard()
    {
        int minR = 0, maxR = 4;
        int IndexR = Random.Range(minR, maxR);
        // 새 카드 생성
        GameObject newCard = Instantiate(cardPrefab[IndexR]);

        // 새 카드의 Y 위치를 조절하여 겹치지 않게 만듭니다.
        Vector3 cardPosition = new Vector3(nextCardX, 0, nextCardZ);
        newCard.transform.position = cardPosition;

        // 다음 카드의 X, Z 위치를 업데이트
        nextCardX += cardXOffset;
        nextCardZ -= cardZOffset;
    }*/
   public CardData PopItem()
    {//카드 사용 후 버퍼에서 삭제
        if(itemBuffer.Count == 0)
        {
            SetupItemBuffer();
        }
        CardData item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }
    void SetupItemBuffer()          
    {
        itemBuffer = new List<CardData>();
        //scene 변수 대신 버퍼 제작
        for(int i=0;i< itemSO.items.Length;i++)
        {
            CardData item = itemSO.items[i];
        }
        for(int i = 0; i < itemBuffer.Count; i++)
        {
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

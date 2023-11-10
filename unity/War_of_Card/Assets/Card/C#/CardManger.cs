using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // 카드 프리팹 => dack

    private float cardXOffset = 15.0f; // 각 카드의 x 축 간격
    private float nextCardX = 0.0f; // 다음 카드의 x 위치
    private float cardZOffset = -1.0f; // 각 카드의 z 축 간격
    private float nextCardZ = 0.0f; // 다음 카드의 z 위치
    private List<GameObject> DackList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateCard();
        }
    }
    void CreateCard()
    {
        // 랜덤한 카드 프리팹을 선택 => dack 안에서 카드 출력
        // cardPrefabs => dack 
        int randomIndex = Random.Range(0, cardPrefabs.Length);
        GameObject newCardPrefab = cardPrefabs[randomIndex];

        // 새 카드 생성 -> 생성된 dack을 삭제하지 않기 위해서 새로운 
        GameObject newCard = Instantiate(newCardPrefab);

        // 새 카드의 위치를 조절하여 겹치지 않게 만듭니다.
        newCard.transform.position += new Vector3(nextCardX, 0, nextCardZ);
        // 다음 카드의 위치를 업데이트
        nextCardX += cardXOffset;
        nextCardZ += cardZOffset;

        DackList.Add(newCard);
    }
    
}
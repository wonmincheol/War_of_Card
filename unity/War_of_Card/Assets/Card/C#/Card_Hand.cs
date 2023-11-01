using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card_Hand : MonoBehaviour
{
    public GameObject[] cardPrefab; // 카드 프리팹
    public Transform cardStack; // 카드 스택을 나타내는 부모 Transform
    private float cardXOffset = 5.0f; // 각 카드의 X 축 간격
    private float nextCardX = 0.0f; // 다음 카드의 X 위치
    private float cardZOffset = 0.5f; // 각 카드의 Z 축 간격
    private float nextCardZ = 0.0f; // 다음 카드의 Z 위치

    private void Update()
    {
        // 특정 키 (예: 'C' 키)를 눌렀을 때 카드를 생성합니다.
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnCard();
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
    }
}

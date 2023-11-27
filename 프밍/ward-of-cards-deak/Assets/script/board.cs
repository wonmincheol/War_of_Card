using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private Material[] cardSprite;
    private List<int> cardIDList = new List<int>();
    private List<car> cardList = new List<car>();
    void Start()
    {
        GenerateCardID();
        InitBoard();
    }
    void GenerateCardID()
    {
        for (int i = 0; i < cardSprite.Length; i++)
        {
            cardIDList.Add(i);
        }
    }
    void InitBoard()
    {
        float spaceY = 5.25f;
        float spaceX = 4.3f;

        int rowCount = 7;
        int colCount = 4;
        int cardIndex = 0;
        for(int row = 0; row < rowCount; row++)
        {
            for(int col = 0; col < colCount; col++)
            {
                float posX = (col - (int)(colCount / 2)) * spaceX ;
                float posY = (row - (int)(rowCount / 2)) * spaceY;
                Vector3 pos = new Vector3(posX, posY, 0f);
                GameObject cardObject= Instantiate(cardPrefab,pos,Quaternion.identity);
                car card = cardObject.GetComponent<car>();
                int cardID = cardIDList[cardIndex++];
                card.setCardID(cardID);
                card.SetanimalSprite(cardSprite[cardID]);
                cardList.Add(card);

            }
        }
    }
 
    public List<car> GetCars()
    {
        return cardList;
    }
        
    }

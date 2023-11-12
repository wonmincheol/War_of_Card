using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    void Start()
    {
        InitBoard();
    }
    void InitBoard()
    {
        float spaceY = 5.25f;
        float spaceX = 4.3f;

        int rowCount = 5;
        int colCount = 4;
        for(int row = 0; row < rowCount; row++)
        {
            for(int col = 0; col < colCount; col++)
            {
                float posX = (col - (int)(colCount / 2)) * spaceX ;
                float posY = (row - (int)(rowCount / 2)) * spaceY;
                Vector3 pos = new Vector3(posX, posY, 0f);
                Instantiate(cardPrefab,pos,Quaternion.identity);
            }
        }
    }
}
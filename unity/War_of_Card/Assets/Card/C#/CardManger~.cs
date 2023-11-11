using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // 카드 프리팹 => dack

    private float cardXOffset = 15.0f; // 각 카드의 x 축 간격
    private float nextCardX = 0.0f; // 다음 카드의 x 위치
    private float cardZOffset = -1.0f; // 각 카드의 z 축 간격
    private float nextCardZ = 0.0f; // 다음 카드의 z 위치
    private List<GameObject> DackList = new List<GameObject>();

    //ui 총괄리자 스크립트
    public Camera camera;

    // 임시로 카드 데이터 public 으로 받아옴
    public GameObject card;

    //카드 올라갈 공간
    GameObject summonObject = null;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();


        //카드 올라갈 공간 지정
        for (int j = 0; j < this.transform.childCount; j++)
        {
            if (this.transform.GetChild(j).name == "CardHint")
            {
                summonObject = this.transform.GetChild(j).gameObject;
            }
        }
    }
    private void Update()
    {
        MouseKeyDown_object();
        MouseKeyUp_object();
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateCard();
        }
    }
    void MouseKeyUp_object()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int j = 0; j < summonObject.transform.childCount; j++)
            {
                Destroy(summonObject.transform.GetChild(j).gameObject);
            }
        }
    }

    //마우스 클릭중일때 해당하는 객체의 카드 데이터 출력
    void MouseKeyDown_object()
    {

        // 좌클릭
        if (Input.GetMouseButton(0))
        {
            GameObject hitObject;


            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //카메라에서 발사한 레이저 히트시
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.transform.gameObject.name);
                hitObject = hit.transform.gameObject;
                // if조건에 알맞는 오브젝트 
                if (true)
                {
                    if (summonObject != null && summonObject.transform.childCount == 0)
                    {
                        Get_Card(hitObject.name).transform.parent = summonObject.transform;
                        GameObject obj = summonObject.transform.GetChild(0).gameObject;
                        if (camera.ScreenToViewportPoint(hitObject.transform.position).x < 0)
                        {
                            obj.transform.localPosition = new Vector3(+250, hitObject.transform.position.y, -120);
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(-250, hitObject.transform.position.y, -120);

                        }
                    }
                }
            }
        }
    }
    public GameObject Get_Card(String s)
    {
        GameObject obj = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject gameObject;
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == "Name")
            {
                gameObject = obj.transform.GetChild(i).gameObject;

                for (int j = 0; j < gameObject.transform.childCount; j++)
                {
                    if (gameObject.transform.GetChild(j).name == "Name_text")
                    {
                        gameObject = gameObject.transform.GetChild(j).gameObject;
                    }
                }
                if (gameObject.name == "Name_text")
                {
                    gameObject.GetComponent<TextMeshPro>().text = s;
                    break;
                }
            }
        }


        obj.transform.parent = this.transform;

        obj.transform.localPosition = new Vector3(0, 0, -120);
        // obj.transform.position=new Vector3(0,0,-120);
        obj.transform.localRotation = Quaternion.identity;
        // obj.transform.rotation = Quaternion.identity;
        obj.transform.localScale = new Vector3(60, 60, 1);
        // obj.transform.localScale = new Vector3(1,1,1);

        return obj;
    }
    void CreateCard()
    {
        // 랜덤한 카드 프리팹을 선택 => dack 안에서 카드 출력
        // cardPrefabs => dack 
        int randomIndex = Random(cardPrefabs.Length);
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
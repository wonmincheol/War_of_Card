using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



enum State { PLCAE, MAGIC, COMMANDER, UNIT, DECK, GY };

public class UI_manager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        MouseKeyDown_object();
        MouseKeyUp_object();
    }


    //마우스 클릭을 땔때 처리
    void MouseKeyUp_object()
    {
        //카드 데이터
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
                State state = State.UNIT;
                //Commander
                if (hitObject.tag == "COMMANDER")
                {
                    state = State.COMMANDER;
                }
                //Magic
                else if (hitObject.tag == "MAGIC")
                {
                    state = State.MAGIC;
                }
                //Place
                else if (hitObject.tag == "PLACE")
                {
                    state = State.PLCAE;
                }
                //Deck
                else if (hitObject.tag == "DECK")
                {
                    state = State.DECK;
                }
                //GY
                else if (hitObject.tag == "GY")
                {
                    state = State.GY;
                }
                //Card
                else
                {
                    state = State.UNIT;
                }



                switch (state)
                {
                    case State.COMMANDER:
                        break;
                    case State.MAGIC:
                        break;
                    case State.PLCAE:
                        break;
                    case State.DECK:
                        break;
                    case State.GY:
                        break;
                    case State.UNIT:
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
                        break;
                    default:
                        break;
                }

            }
        }
    }

    // 인풋으로 알맞는 카드 찾아서 가져오기
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

}

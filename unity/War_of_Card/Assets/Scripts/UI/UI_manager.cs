using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



enum State { PLCAE, MAGIC, COMMANDER, UNIT, DECK, GY, CARD, NULL, FIELD };

public class UI_manager : MonoBehaviour
{
    //ui 총괄리자 스크립트
    public Camera camera;

    // 임시로 카드 데이터 public 으로 받아옴
    public GameObject card;

    //cost
    public int Cost;
    //카드 올라갈 공간
    GameObject summonObject = null;

    //코스트 자식 오브젝트
    GameObject Cost_object = null;
    // Start is called before the first frame update


    public GameObject SelectObject;

    public List<GameObject> Cost_List = new List<GameObject>();
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();



        for (int j = 0; j < this.transform.childCount; j++)
        {
            //카드 올라갈 공간 지정
            if (this.transform.GetChild(j).name == "CardHint")
            {
                summonObject = this.transform.GetChild(j).gameObject;
            }
            else if (this.transform.GetChild(j).name == "Cost_Area")
            {
                Cost_object = this.transform.GetChild(j).gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseKeyDown_object();
        MouseKeyUp_object();
        Apply_Cost();
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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hitObject;


            //default
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            //canvas
            GraphicRaycaster graphicRaycaster = this.GetComponent<GraphicRaycaster>();
            PointerEventData pointerEventData = new PointerEventData(null);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> result = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, result);



            //카메라에서 발사한 레이저 히트시
            if (Physics.Raycast(ray, out hit) || (result.Count > 0))
            {
                // Debug.Log(hit.transform.gameObject.name);
                hitObject = hit.transform.gameObject;

                if (hitObject != null)
                {
                    Debug.Log("hit : " + hitObject.name);
                }
                if (result.Count > 0)
                {
                    Debug.Log("hit_UI : " + result[0].gameObject.name);
                }

                // if조건에 알맞는 오브젝트 
                State state = State.NULL;
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
                else if (hitObject.tag == "UNIT")
                {
                    state = State.UNIT;
                }
                else if ((result.Count > 0) && result[0].gameObject.tag == "Card")
                {
                    state = State.CARD;
                }
                else if (hitObject.tag == "FIELD")
                {
                    state = State.FIELD;
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
                        UI_hand ui_hand = null;
                        for (int i = 0; i < this.transform.childCount; i++)
                        {
                            if (this.transform.GetChild(i).GetComponent<UI_hand>() != null)
                            {
                                ui_hand = this.transform.GetChild(i).GetComponent<UI_hand>();
                            }
                        }
                        if (ui_hand != null)
                        {
                            ui_hand.Draw();
                        }
                        break;
                    case State.GY:
                        break;
                    case State.UNIT:
                        if (true)
                        {
                            if (summonObject != null && summonObject.transform.childCount == 0)
                            {
                                Debug.Log("hitobject : " + hitObject.name);
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


                                SelectObject = hitObject;
                                SelectObject.transform.parent.parent.gameObject.GetComponent<FieldSet>().clean_field();

                                SelectObject.GetComponent<UnitMovement>().select();

                            }
                        }
                        break;
                    case State.CARD:
                        break;
                    case State.FIELD:

                        if (SelectObject != null && hitObject.GetComponent<FieldState>().move_possible_point == true)
                        {
                            SelectObject.transform.parent = hitObject.transform;
                            SelectObject.GetComponent<UnitMovement>().MoveTarget = hitObject.transform.position;
                            SelectObject.transform.parent.parent.gameObject.GetComponent<FieldSet>().clean_field();
                            SelectObject = null;

                        }


                        break;
                    default:
                        break;
                }

            }
        }
    }


    void Mouse_Hoverling()
    {

    }


    // 인풋으로 알맞는 카드 찾아서 가져오기
    public GameObject Get_Card(String s)
    {
        GameObject obj = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject gameObject;
        Boolean check_name_set = false;
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == "Canves")
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
                    check_name_set = true;
                    break;
                }
            }
        }

        obj.transform.parent = this.transform;

        obj.transform.localPosition = new Vector3(0, 0, 0);
        // obj.transform.position=new Vector3(0,0,-120);
        obj.transform.localRotation = Quaternion.identity;
        // obj.transform.rotation = Quaternion.identity;
        obj.transform.localScale = new Vector3(60, 60, 1);
        // obj.transform.localScale = new Vector3(1,1,1);

        return obj;
    }





    public void Apply_Cost()
    {
        for (int i = 1; i <= Cost_List.Count; i++)
        {
            if (i <= Cost)
            {
                Cost_List[i - 1].SetActive(true);
            }
            else
            {
                Cost_List[i - 1].SetActive(false);
            }
        }





    }

}

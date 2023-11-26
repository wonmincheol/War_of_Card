using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using UnityEngine;

public class UI_handMove : MonoBehaviour
{


    public Vector3 myPos = Vector3.zero;
    public Boolean close_point = false;
    Vector3 defaultVector;

    enum State { hand, follow };


    private Vector3 normalSize;
    private Camera camera;
    private Camera Main_camera;
    private float default_Z;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("UI Camera").GetComponent<Camera>();
        Main_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        defaultVector = new Vector3(0, 0, -120);
        transform.localPosition = defaultVector;
        state = State.hand;
        normalSize = transform.localScale;
        default_Z = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        size_apliy();
        toHand();
        click_check();
    }

    void toHand()
    {
        if (myPos != Vector3.zero && state == State.hand)
        {
            transform.localPosition = Vector3.Lerp(this.transform.localPosition, myPos, 0.035f);
        }
    }

    void size_apliy()
    {

        if (state == State.hand)
        {
            if (close_point == true)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, default_Z - 10);
                transform.localScale = normalSize * 1.1f;
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, default_Z);
                transform.localScale = normalSize;
            }
        }
    }

    void click_check()
    {
        if ((Input.GetMouseButton(0) == true) && (close_point == true))
        {
            state = State.follow;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Vector3 point = new Vector3(0, 0, 0);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                point = hit.point;
                // UnityEngine.Debug.Log("Test : " + point);
                transform.position = Vector3.Lerp(this.transform.position, new Vector3(point.x, point.y, transform.position.z), 0.5f);
            }
        }
        else
        {
            state = State.hand;
        }

        if ((Input.GetMouseButtonUp(0) == true) && (close_point == true))
        {
            if ((transform.localPosition.y) > 0)
            {
                UnityEngine.Debug.Log("Use Card");
                DestoryThis();
            }
        }
    }

    void DestoryThis()
    {
        GameObject hand = this.transform.parent.gameObject;
        UI_hand ui_Hand = hand.GetComponent<UI_hand>();
        foreach (GameObject now in ui_Hand.Myhand)
        {
            if (now == this.gameObject)
            {
                ui_Hand.Myhand.Remove(now);
                ui_Hand.count--;
                ui_Hand.hand_position();

                GameObject init = Instantiate(this.transform.parent.GetComponent<UI_hand>().unit_prefabs, Vector3.zero, Quaternion.identity);
                init.name = this.gameObject.GetComponent<Card_Unit>().card_date.card_Name;
                this.transform.parent.parent.gameObject.GetComponent<UI_manager>().SelectObject = init;
                GameObject.Find("PlaneGroup").GetComponent<FieldSet>().full_field();

                Destroy(this.gameObject);
                return;
            }
        }


    }


}

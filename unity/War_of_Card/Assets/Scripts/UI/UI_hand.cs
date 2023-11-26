using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_hand : MonoBehaviour
{
    //Temp : Card_generate develop
    public GameObject unit_card;
    public GameObject commander_card;
    public GameObject Magic_card;
    public GameObject place_card;

    public GameObject Deck;

    public Camera camera;
    public int count;

    public List<GameObject> Myhand = new List<GameObject>();

    public LayerMask layer;
    const int Max_hand = 10;

    int now_hand;
    public float card_padding;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;


        now_hand = 0;
        Myhand.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Draw();

        }
        try
        {
            Select_card();
        }
        catch (ObjectDisposedException e)
        {
            Debug.Log(e);
        }
    }

    public void hand_position()
    {
        // position gen
        List<float> pos = new List<float>();

        if ((count % 2) == 0)
        {
            int c = count / 2;
            for (int i = 0; i < c; i++)
            {
                float n = i * card_padding + card_padding / 2;
                pos.Add(n);
                pos.Add(-n);
            }
        }
        else
        {
            pos.Add(0);
            int c = (count - 1) / 2;
            for (int i = 0; i < c; i++)
            {
                float n = i * card_padding + card_padding;
                pos.Add(n);
                pos.Add(-n);
            }
        }

        pos.Sort();

        float card_padding_z = 100;
        // position gen
        List<float> pos_z = new List<float>();

        if ((count % 2) == 0)
        {
            int c = count / 2;
            for (int i = 0; i < c; i++)
            {
                float n = i * card_padding_z + card_padding_z / 2;
                pos_z.Add(n);
                pos_z.Add(-n);
            }
        }
        else
        {
            pos_z.Add(0);
            int c = (count - 1) / 2;
            for (int i = 0; i < c; i++)
            {
                float n = i * card_padding_z + card_padding_z;
                pos_z.Add(n);
                pos_z.Add(-n);
            }
        }

        pos_z.Sort();

        // Debug.Log(string.Join(",", pos));



        //pos adapt
        for (int i = 0; i < Myhand.Count; i++)
        {
            Myhand[i].GetComponent<UI_handMove>().myPos = new Vector3(pos[i], -150, -120 + pos_z[i]);
        }
    }


    void Select_card()
    {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 point = new Vector3(0, 0, 0);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.gameObject.tag == "Card")
            {
                point = hit.point;
            }
            else
            {
                foreach (GameObject my_hand in Myhand)
                {
                    my_hand.GetComponent<UI_handMove>().close_point = false;
                }
                return;

            }
        }
        else
        {
            foreach (GameObject my_hand in Myhand)
            {
                my_hand.GetComponent<UI_handMove>().close_point = false;
            }
            return;
        }

        float length_min = 30;
        GameObject close_gameobject = null;
        foreach (GameObject my_hand in Myhand)
        {
            float now_length = ((my_hand.transform.position) - point).magnitude;
            // Debug.Log("len : " + now_length);
            if (now_length < length_min)
            {
                length_min = now_length;
                close_gameobject = my_hand;
            }
        }
        // Debug.Log("object : " + close_gameobject.transform.position);
        // Debug.Log("mouse : " + point);


        List<Boolean> test = new List<Boolean>();
        foreach (GameObject my_hand in Myhand)
        {
            if (close_gameobject == my_hand)
            {
                my_hand.GetComponent<UI_handMove>().close_point = true;
                test.Add(true);
            }
            else
            {
                my_hand.GetComponent<UI_handMove>().close_point = false;
                test.Add(false);
            }
        }
        // Debug.Log(string.Join(",", test));

    }


    public void Draw(/*int id*/)
    {
        if (count == Max_hand || Deck.GetComponent<Deck_List>().deck.Count == 0)
        {
            return;
        }

        GameObject obj = Instantiate(unit_card, new Vector3(0, 0, 0), Quaternion.identity);

        // obj.GetComponent<Card_Unit>().set_Data(1001);

        GameObject gameObject;

        obj.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * 5, this.gameObject.transform.localScale.y * 5, this.gameObject.transform.localScale.z);


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
                    gameObject.GetComponent<TextMeshPro>().text = count.ToString();
                    count++;
                    break;
                }
            }
        }









        obj.transform.parent = this.transform;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localPosition = new Vector3(0, 0, -120);
        obj.AddComponent<UI_handMove>();
        obj.AddComponent<Card_Unit>();
        //id 수정 필요

        int index = Deck.GetComponent<Deck_List>().deck.Count;

        index = UnityEngine.Random.Range(0, index - 1);

        index = Deck.GetComponent<Deck_List>().deck[index];
        Deck.GetComponent<Deck_List>().deck.Remove(index);

        Debug.Log("index : " + index);
        obj.GetComponent<Card_Unit>().set_Data(index);


        Myhand.Add(obj);
        count++;

        hand_position();


    }
}

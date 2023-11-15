using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UI_hand : MonoBehaviour
{
    //Temp : Card_generate develop
    public GameObject card;
    public int count;

    public List<GameObject> Myhand = new List<GameObject>();

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
            hand_position();
        }
    }

    void hand_position()
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

        Debug.Log(string.Join(",", pos));



        //pos adapt
        for (int i = 0; i < Myhand.Count; i++)
        {
            Myhand[i].GetComponent<UI_handMove>().myPos = new Vector3(pos[i], -150, -120);
        }
    }


    void Draw(/*int id*/)
    {
        if (count == Max_hand)
        {
            return;
        }

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

        Myhand.Add(obj);
        count++;




    }
}

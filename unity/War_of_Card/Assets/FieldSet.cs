using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;





public class FieldSet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[,] map;


    public GameObject point;
    void Start()
    {
        set_field();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clean_field()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                map[i, j].GetComponent<FieldState>().move_possible_point = false;
            }
        }
    }

    public void full_field()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                map[i, j].GetComponent<FieldState>().move_possible_point = true;
            }
        }
    }
    void set_field()
    {
        map = new GameObject[6, 5];

        for (int i = 0; i < 30; i++)
        {
            map[i / 5, i % 5] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject now = map[i, j];



                now.AddComponent<FieldState>();
                FieldState fieldSet = now.GetComponent<FieldState>();

                fieldSet.point = Instantiate(point, Vector3.zero, Quaternion.identity);
                fieldSet.point.transform.parent = now.transform;

                fieldSet.point.transform.localPosition = new Vector3(0, 1, 0);
            }
        }



    }

}

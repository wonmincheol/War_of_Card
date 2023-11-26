using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FieldState : MonoBehaviour
{

    public GameObject now_unit;
    public Boolean move_possible_point;

    public GameObject point;



    // Start is called before the first frame update
    void Start()
    {
        move_possible_point = false;
    }

    // Update is called once per frame
    void Update()
    {
        set_point();
    }

    public void set_point()
    {
        if (move_possible_point == true && point.activeSelf == false)
        {
            point.SetActive(true);
        }
        else if (move_possible_point == false && point.activeSelf == true)
        {
            point.SetActive(false);
        }
    }

}

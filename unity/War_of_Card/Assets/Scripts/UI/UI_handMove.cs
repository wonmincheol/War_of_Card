using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class UI_handMove : MonoBehaviour
{
    public Vector3 myPos = Vector3.zero;
    public Boolean close_point = false;
    Vector3 defaultVector;

    enum State { hand, follow };


    private Vector3 normalSize;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        defaultVector = new Vector3(0, 0, -120);
        transform.localPosition = defaultVector;
        state = State.hand;
        normalSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        size_apliy();
        toHand();
    }

    void toHand()
    {
        if (myPos != Vector3.zero && state == State.hand)
        {
            transform.localPosition = Vector3.Lerp(this.transform.localPosition, myPos, 0.007f);
        }
    }

    void size_apliy()
    {

        if (close_point == true)
        {
            transform.localScale = normalSize * 1.1f;
        }
        else
        {
            transform.localScale = normalSize;
        }


    }

}

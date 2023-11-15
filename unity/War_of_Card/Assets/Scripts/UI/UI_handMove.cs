using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_handMove : MonoBehaviour
{
    public Vector3 myPos = Vector3.zero;

    Vector3 defaultVector;
    // Start is called before the first frame update
    void Start()
    {
        defaultVector = new Vector3(0, 0, -120);
        transform.localPosition = defaultVector;

    }

    // Update is called once per frame
    void Update()
    {
        if (myPos != Vector3.zero)
        {
            transform.localPosition = Vector3.Lerp(this.transform.localPosition, myPos, 0.007f);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Vector3 MoveTarget = Vector3.zero;


    public Material[] materials;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (MoveTarget != Vector3.zero && MoveTarget != this.transform.position)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, MoveTarget, 0.05f);
        }
    }
    public void select()
    {
        Vector2[] dir = {
            Vector2.left,
            Vector2.down,
            Vector2.right,
            Vector2.up
        };
        GameObject[,] map = this.transform.parent.parent.GetComponent<FieldSet>().map;
        Vector2 now = new Vector2(-1, -1);
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (map[row, col] == this.transform.parent.gameObject)
                {
                    now = new Vector2(row, col);
                }
            }
        }

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                foreach (Vector2 now_dir in dir)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if ((now != new Vector2(-1, -1)) && ((now_dir * i + now) == new Vector2(row, col)))
                        {
                            FieldState fieldState = map[row, col].GetComponent<FieldState>();
                            if (fieldState.now_unit == null)
                            {
                                fieldState.move_possible_point = true;
                            }
                        }
                    }
                }
            }
        }

    }
}

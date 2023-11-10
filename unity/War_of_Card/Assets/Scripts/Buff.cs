using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buff : MonoBehaviour
{
    public List<GameObject> buff_Target = new List<GameObject>();
}
public class Enchant : Buff
{
    private string buff_name;
    private int add_Damage;
    private int add_Max_HP;
    public Enchant(int d, int h)
    {
        add_Damage = d;
        add_Max_HP = h;
        buff_name = "°­È­(" + add_Damage.ToString() + ", " + add_Max_HP.ToString() + ")";
    }
}

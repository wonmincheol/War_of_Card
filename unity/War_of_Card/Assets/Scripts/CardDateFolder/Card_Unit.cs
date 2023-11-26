using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card_Unit : MonoBehaviour
{
    GameObject data_Arr;
    Unit_Card card_date;



    // Start is called before the first frame update
    void Awake()
    {
        card_date = new Unit_Card();
    }

    public void set_Data(int id)
    {
        data_Arr = GameObject.Find("GameManager");
        Debug.Log("set_data : " + id);
        card_date.card_Type = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Type;
        card_date.card_Name = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Name;
        card_date.card_Cost = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Cost;
        card_date.card_Sprite = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Sprite;
        card_date.card_Description = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Description;
        card_date.max_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.now_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.damage = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].damage;
        update_Data_AllText();
    }
    public void update_Data_AllText() // ��� �ؽ�Ʈ ���� �Լ� �ؿ��� �̸� �״�� �ؽ�Ʈ ������Ʈ
    {
        update_Data_NameText();
        update_Data_DescriptionText();
        update_Data_DamageText();
        update_Data_HealthText();
        update_Data_CostText();
    }
    public void update_Data_NameText()
    {
        transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = card_date.card_Name;
    }
    public void update_Data_DescriptionText()
    {
        transform.GetChild(1).GetChild(4).GetComponent<TextMeshPro>().text = card_date.card_Description;
    }
    public void update_Data_DamageText()
    {
        transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<TextMeshPro>().text = card_date.damage.ToString();
    }
    public void update_Data_HealthText()
    {
        transform.GetChild(1).GetChild(6).GetChild(0).GetComponent<TextMeshPro>().text = card_date.now_HP.ToString();
    }
    public void update_Data_CostText()
    {
        transform.GetChild(1).GetChild(7).GetChild(0).GetComponent<TextMeshPro>().text = card_date.card_Cost.ToString();
    }
    /* ���� �̵� �̱���
    public void update_Data_MovingText()
    {
        transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<TextMeshPro>().text = card_date.;
    }
    */
}

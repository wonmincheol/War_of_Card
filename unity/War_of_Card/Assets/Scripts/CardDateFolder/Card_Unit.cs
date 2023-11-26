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
        set_Data(1001);
        update_Data_AllText();
    }

    public void set_Data(int id)
    {
        data_Arr = GameObject.Find("GameManager");
        card_date.card_Type = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Type;
        card_date.card_Name = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Name;
        card_date.card_Cost = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Cost;
        card_date.card_Sprite = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Sprite;
        card_date.card_Description = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].card_Description;
        card_date.max_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.now_HP = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].max_HP;
        card_date.damage = data_Arr.GetComponent<GameManager>().dataForms[(id / 1000) - 1].dataList[id % 1000 - 1].damage;
    }
    public void update_Data_AllText() // 모든 텍스트 적용 함수 밑에는 이름 그대로 텍스트 업데이트
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
    /* 현재 이동 미구현
    public void update_Data_MovingText()
    {
        transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<TextMeshPro>().text = card_date.;
    }
    */
}

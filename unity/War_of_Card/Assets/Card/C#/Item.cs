using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item 
{
    public string name;
    public int attack;
    public int health;
    public Sprite sprite;
    public float percent;
    public enum kind{c,m };
    public string Description;
}
//[CreateAssetMenu(fileName =)] 
public class ItemSO : ScriptableObject
    // 파일 이름 ItemSO
{
    public Item[] items;
    //Item 리스트 내용은 위에 존재
}
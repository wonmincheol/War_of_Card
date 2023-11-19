using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour 
{
    public ArrCardData[] dataForms;
    public List<CardData> commander_DataList = new List<CardData>();
    public List<CardData> unit_DataList = new List<CardData>();
    public List<CardData> magic_DataList = new List<CardData>();
    public List<Buff> buff_manager = new List<Buff>();
}

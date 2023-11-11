using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] Renderer[] backrender;
    int originOrder;
    void setoriginOrder(int originOrder)
    {
        this.originOrder = originOrder;
        SetOrder(originOrder);
    }
    void MousFront(bool isMouson)
    {//Hit로 변경하여 카드의 선택 유무 확인 예정
        SetOrder(isMouson ? 100 : originOrder);
    }
    void SetOrder(int order)
    {
        int mulOrder = order * 10; // 간격으로 전환 예정
        foreach (var renderer in backrender) 
        {
            renderer.sortingOrder = mulOrder;
        }
    }
    private void Start()
    {
        SetOrder(0);
    }

}

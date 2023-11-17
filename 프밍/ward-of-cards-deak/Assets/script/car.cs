using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class car : MonoBehaviour
{
    [SerializeField]
    private Material AnimalSprite;
    [SerializeField]
    private Renderer cardlender;
    [SerializeField]
    private Material backSprite;
    private bool isFlipped=false;
    private bool isFlipping = false;
    public int cardID;
    public void setCardID(int id)
    {
        cardID = id;

    }

    public void SetanimalSprite(Material sprite)
    {
        AnimalSprite = sprite;
    }
    public void FlipCard()
    {
        isFlipping = true;

        Vector3 orignalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, orignalScale.y, orignalScale.z);
        transform.DOScale(targetScale, 0.2f).OnComplete(() =>
        {
            isFlipped = !isFlipped;
            if (isFlipped)
            {
                cardlender.material= AnimalSprite;
            }
            else
            {
                cardlender.material = backSprite;
            }
            transform.DOScale(orignalScale, 0.2f).OnComplete(() =>
            {
                isFlipping = false;
            });
        });
        
    }
    void OnMouseDown()
    {
        if (!isFlipping)
        {
            FlipCard();
        }
    }
}

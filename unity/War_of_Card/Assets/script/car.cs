using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

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
    private bool Moving = false;
    public int cardID;
    private Vector3 orignalPosition;
    private Vector3 Targetposition;
    private float cardInterval = 2.0f;
    void Start()
    {
        orignalPosition = transform.position;
    }
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
                MoveCardToPosition(orignalPosition);
            }
            else
            {
                cardlender.material = backSprite;
                MoveCardToPosition((orignalPosition)+new Vector3(20, 0, 0));
            }
            transform.DOScale(orignalScale, 0.2f).OnComplete(() =>
            {
                isFlipping = false;
            });
        });
        
    }
    void MoveCardToPosition(Vector3 destination)
    {
        // 현재 카드의 위치에서 목표 위치로 이동
        Targetposition  =destination;

        // 카드 이동 애니메이션 실행
        Moving = true;
    }
    void OnMouseDown()
    {
        
        if (!isFlipping)
        {
            FlipCard();
        }
    }
    void FixedUpdate()
    {
        // 카드가 이동 중인 경우 지속적으로 해당 좌표로 이동
        if (Moving)
        {
            float step = 10f * Time.fixedDeltaTime; // 이동 속도 조절
            transform.position = Vector3.MoveTowards(transform.position, Targetposition, step);

            // 목표 위치에 도착하면 이동 종료
            if (Vector3.Distance(transform.position, Targetposition) < 0.01f)
            {
                Moving = false;
            }
        }
    }
}
    
    

    

using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject cardDeck; // CardDeck으로 묶은 부모 오브젝트를 인스펙터에서 할당해주세요.
    public GameObject cardPrefab; // Card 프리팹을 인스펙터에서 할당해주세요.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceRandomCard();
        }
    }

    void PlaceRandomCard()
    {
        Transform[] cards = cardDeck.GetComponentsInChildren<Transform>();

        if (cards.Length > 1)
        {
            // 랜덤한 인덱스 선택
            int randomIndex = Random.Range(1, cards.Length);

            // 선택된 Card 프리팹을 복제하여 새로운 오브젝트 생성
            GameObject newCard = Instantiate(cardPrefab);

            Vector3 newPosition = new Vector3(67f, 34f, -19f); // 오른쪽 하단

            // 최대 5번 시도하여 겹치지 않는 위치 찾기
            int maxAttempts = 5;
            int attempts = 0;

            while (CheckOverlap(newPosition, 1.0f) && attempts < maxAttempts)
            {
                newPosition.x -= 10f; // 왼쪽으로 10 단위 이동
                attempts++;
            }

            newCard.transform.position = newPosition;

            // 회전과 크기 적용
            newCard.transform.rotation = Quaternion.Euler(0, 180, 0);
            newCard.transform.localScale = new Vector3(8f, 2f, 14f);
        }
    }

    // 주어진 위치 주변에 다른 카드가 있는지 확인하는 함수
    bool CheckOverlap(Vector3 position, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, radius); // 반지름 radius의 구를 사용하여 충돌 체크

        return hitColliders.Length > 0;
    }
}

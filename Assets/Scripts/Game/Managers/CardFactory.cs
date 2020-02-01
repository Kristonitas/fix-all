using System.Collections;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public Card cardPrefab;
    public Transform cardContainer;

    void Start()
    {
        CardImporter.Import();
        CreateCard();

        // TODO: move out of CardFactory
        EventCoordinator.StartListening(EventName.Input.Swipe.FinishRight(), OnSwipeRight);
        EventCoordinator.StartListening(EventName.Input.Swipe.FinishLeft(), OnSwipeLeft);
    }

    void CreateCard()
    {
        CardData cardData = CardCoordinator.GetCard(0);
        Card card = this.cardPrefab.CreateCard(cardData);
        card.transform.parent = cardContainer;
    }

    IEnumerator DelayCreateCard()
    {
        yield return new WaitForSeconds(1);
        CreateCard();
    }

    void OnSwipeRight(GameMessage msg)
    {
        StartCoroutine(DelayCreateCard());
    }

    void OnSwipeLeft(GameMessage msg)
    {
        StartCoroutine(DelayCreateCard());
    }
}

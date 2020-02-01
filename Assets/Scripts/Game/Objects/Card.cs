using UnityEngine;
// using UnityEngine.UIElements;
public class Card : MonoBehaviour
{
    public CardData cardData;
    // public Image coverImage;
    public SpriteRenderer renderer;

    public Card CreateCard(CardData inputCardData)
    {
        GameObject newCardGO = Instantiate(this.gameObject);
        Card newCard = newCardGO.GetComponent<Card>();
        newCard.cardData = inputCardData;
        newCard.renderer.sprite = inputCardData.coverImage;

        return newCard;
    }
}

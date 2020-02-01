using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Card : MonoBehaviour
{
    public CardData cardData;
    public Image coverImage;

    public GameObject CreateCard (CardData inputCardData){
        GameObject newCardGO = Instantiate(this.gameObject);
        Card newCard = newCardGO.GetComponent<Card>();
        newCard.cardData = inputCardData;
        newCard.coverImage.image = inputCardData.coverImage.texture;
        return newCardGO;
    }
}

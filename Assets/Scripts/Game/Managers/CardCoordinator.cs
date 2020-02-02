using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCoordinator : Singleton<CardCoordinator>
{
    List<CardData> cards = new List<CardData>();
    int currentCardIndex = 0;
    public static void AddCard(CardData newCardData){
        Instance.cards.Add(newCardData);
    }

    public static CardData GetCard(int index){
        if(Instance.cards.Count > index){
            return Instance.cards[index];
        } else {
            Debug.LogError("Index of GetCard too high, not enough cards in list!");
            return null;
        }
    }
    public static CardData GetNextCardData(){
        if(Instance.cards.Count > Instance.currentCardIndex){
            return Instance.cards[Instance.currentCardIndex];
        } else {
            Debug.LogError("Out of cards, not enough cards in list!");
            return null;
        }
    }
    public static void RandomizeCardsForPlayer(){
        Random.InitState(PlayerDataBucket.GetPlayerName().GetHashCode());
        for(int i = 0; i < Instance.cards.Count; i++){
            bool tapeIsRightResrouce  = (Random.value > 0.5f);
            if(tapeIsRightResrouce)
                Instance.cards[i].correctResrouce = ResourceItem.Ductape;
            else
                Instance.cards[i].correctResrouce = ResourceItem.Wd;

            CardData tempCard = Instance.cards[i];
            int randomIndex = Random.Range(i, Instance.cards.Count);
            Instance.cards[i] = Instance.cards[randomIndex];
            Instance.cards[randomIndex] = tempCard;
        }
    }
}   

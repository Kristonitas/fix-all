using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCoordinator : Singleton<CardCoordinator>
{
    List<CardData> cards = new List<CardData>();

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

    public static void RandomizeCardResources(){
        foreach(CardData card in Instance.cards){
            
        }
    }
}   

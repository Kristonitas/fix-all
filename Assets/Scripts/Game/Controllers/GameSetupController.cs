using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.System.CardsImported(), OnCardsImported);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.CardsImported(), OnCardsImported);
    }

    void OnCardsImported(GameMessage msg)
    {
        CardCoordinator.RandomizeCardsForPlayer();
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(0).WithResource(ResourceItem.Ductape));
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(0).WithResource(ResourceItem.Wd));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnGameStart);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.Input.StartGame(), OnGameStart);
    }

    void OnGameStart(GameMessage msg)
    {
        CardCoordinator.RandomizeCardsForPlayer();
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(0).WithResource(ResourceItem.Ductape));
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(0).WithResource(ResourceItem.Wd));
    }
}

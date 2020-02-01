using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndHandler : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.System.Economy.ResourceChanged(), OnResourceChanged);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.Economy.ResourceChanged(), OnResourceChanged);
    }
    void OnResourceChanged(GameMessage msg)
    {
        if(PlayerDataBucket.IsAnyResourceEmpty())
            EventCoordinator.TriggerEvent(EventName.System.EndGame(), GameMessage.Write());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventChain : MonoBehaviour {
    void Start () {
        EventCoordinator.Attach(EventName.System.EndGame(), OnEndGame);
    }
    void OnDestroy() {
        EventCoordinator.Detach(EventName.System.EndGame(), OnEndGame);
    }
    void OnEndGame(GameMessage msg)
    {
        EventCoordinator.TriggerEvent(EventName.UI.ShowPostScreen(), GameMessage.Write());
    }
}
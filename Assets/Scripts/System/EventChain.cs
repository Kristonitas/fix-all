using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventChain : MonoBehaviour {
    void Start () {
        EventCoordinator.Attach(EventName.System.EndGame(), OnEndGame);
        EventCoordinator.Attach(EventName.Input.StartGame(), OnGameStart);
    }
    void OnDestroy() {
        EventCoordinator.Detach(EventName.System.EndGame(), OnEndGame);
        EventCoordinator.Detach(EventName.Input.StartGame(), OnGameStart);
    }
    void OnEndGame(GameMessage msg)
    {
        EventCoordinator.TriggerEvent(EventName.UI.ShowPostScreen(), GameMessage.Write());
    }
    void OnGameStart(GameMessage msg){
        EventCoordinator.TriggerEvent(EventName.System.MatchStarted(), msg);
    }
}
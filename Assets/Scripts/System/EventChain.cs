using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventChain : MonoBehaviour {
    void Start () {
        EventCoordinator.Attach(EventName.Input.StartGame(), OnStartGame);
    }
    void OnDestroy() {
        EventCoordinator.Detach(EventName.Input.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg)
    {
        EventCoordinator.TriggerEvent(EventName.System.Environment.Initialized(), msg);
    }

}
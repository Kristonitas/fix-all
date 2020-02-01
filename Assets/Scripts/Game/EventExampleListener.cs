using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExampleListener : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnStartGame);
    }

    void OnStartGame(GameMessage msg)
    {
        Debug.Log("GameStarted! "+msg.strMessage);
    }
}

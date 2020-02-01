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
        PlayerDataBucket.SetPlayerName(msg.strMessage);
        CardCoordinator.RandomizeCardsForPlayer();
    }
}

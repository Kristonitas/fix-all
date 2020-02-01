using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject startViewPanel;
    public GameObject matchViewPanel;
    
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnGameStart);
        EventCoordinator.StartListening(EventName.Input.ResetGame(), OnGameReset);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.Input.StartGame(), OnGameStart);
        EventCoordinator.StopListening(EventName.Input.ResetGame(), OnGameReset);
    }
    void OnGameStart(GameMessage msg)
    {
        startViewPanel.SetActive(false);
        matchViewPanel.SetActive(true);
    }
    void OnGameReset(GameMessage msg)
    {
        startViewPanel.SetActive(true);
        matchViewPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject startViewPanel;
    public GameObject matchViewPanel;
    public GameObject postViewPanel;
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnGameStart);
        EventCoordinator.StartListening(EventName.Input.ResetGame(), OnGameReset);
        EventCoordinator.StartListening(EventName.System.EndGame(), OnEndGame);
        GameLaunched();
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.Input.StartGame(), OnGameStart);
        EventCoordinator.StopListening(EventName.Input.ResetGame(), OnGameReset);
        EventCoordinator.StopListening(EventName.System.EndGame(), OnEndGame);
    }
    void OnGameStart(GameMessage msg)
    {
        startViewPanel.SetActive(false);
        matchViewPanel.SetActive(true);
        postViewPanel.SetActive(false);
    }
    void OnGameReset(GameMessage msg)
    {
        startViewPanel.SetActive(true);
        matchViewPanel.SetActive(false);
        postViewPanel.SetActive(false);
    }
    void OnEndGame(GameMessage msg){
        startViewPanel.SetActive(false);
        matchViewPanel.SetActive(false);
        postViewPanel.SetActive(true);
    }
    void GameLaunched(){
        startViewPanel.SetActive(true);
        matchViewPanel.SetActive(false);
        postViewPanel.SetActive(false);
    }
}

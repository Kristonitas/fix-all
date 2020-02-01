using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWriter : MonoBehaviour
{
    public List<GuessResult> results = new List<GuessResult>();
    public Transform resultTileContainer;
    public CardResultTile resultTilePrefab;
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.CardSelected(), OnCardSelected);
        EventCoordinator.StartListening(EventName.UI.ShowPostScreen(), OnShowPostScreen);
    }
    void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.Input.CardSelected(), OnCardSelected);
        EventCoordinator.StopListening(EventName.UI.ShowPostScreen(), OnShowPostScreen);
    }
    // Update is called once per frame
    void OnCardSelected(GameMessage msg)
    {
        results.Add(new GuessResult(msg.cardData, msg.resourceItem));
    }
    void OnShowPostScreen(GameMessage msg){
        for(int i = 0; i < results.Count; i++){
            GameObject res = resultTilePrefab.Create(results[i]);
            res.transform.parent = resultTileContainer;
        }
    }
}

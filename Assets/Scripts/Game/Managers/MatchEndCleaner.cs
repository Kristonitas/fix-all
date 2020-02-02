using UnityEngine;

public class MatchEndCleaner : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.System.MatchStarted(), ClearCards);
        EventCoordinator.StartListening(EventName.System.EndGame(), ClearCards);
    }

    void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.System.MatchStarted(), ClearCards);
        EventCoordinator.StopListening(EventName.System.EndGame(), ClearCards);
    }

    void ClearCards(GameMessage msg)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

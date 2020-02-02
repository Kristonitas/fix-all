using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.System.CardsImported(), OnCardsImported);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.CardsImported(), OnCardsImported);
    }

    void OnCardsImported(GameMessage msg)
    {
        CardCoordinator.RandomizeCardsForPlayer();
        float wdAmount = 0;
        float tapeAmount = 0;
        if(PlayerPrefs.GetInt("Ending1") > 0)
            wdAmount += GameConstantsBucket.EndingResourceAward;
        if(PlayerPrefs.GetInt("Ending2") > 0)
            tapeAmount += GameConstantsBucket.EndingResourceAward;
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(tapeAmount).WithResource(ResourceItem.Ductape));
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(wdAmount).WithResource(ResourceItem.Wd));
    }
}

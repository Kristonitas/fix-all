using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EndingsUnlocker : MonoBehaviour
{
    public float correctTape = 0;
    public float correctWd = 0;
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.CardSelected(), OnModifyResource);
        EventCoordinator.StartListening(EventName.System.EndGame(), OnEndGame);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.Input.CardSelected(), OnModifyResource);
        EventCoordinator.StopListening(EventName.System.EndGame(), OnEndGame);
    }
    void OnModifyResource(GameMessage msg)
    {
        if(msg.resourceItem == msg.cardData.correctResrouce){
            Answer answer = msg.cardData.answers.Where(x => x.good && x.resource == msg.resourceItem).FirstOrDefault();
            switch(msg.resourceItem){
                case ResourceItem.Ductape:
                    correctTape += answer.cost;
                    break;
                case ResourceItem.Wd:
                    correctWd+= answer.cost;
                    break;
            }
        }
    }
    void OnEndGame(GameMessage msg){
        if(correctTape * GameConstantsBucket.EndingResourceMultiplier > correctWd){
            EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(0));
        }else{
            if(correctTape < correctWd * GameConstantsBucket.EndingResourceMultiplier){
                EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(1));
            }else{
                if(Mathf.Abs(correctTape - correctWd) < GameConstantsBucket.EndingResourceDifference)
                    EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(2));
            }
        }
    }
}

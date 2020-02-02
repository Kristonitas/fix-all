using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ResourceConsumer : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.CardSelected(), OnModifyResource);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.Input.CardSelected(), OnModifyResource);
    }
    void OnModifyResource(GameMessage msg)
    {
        bool goodSelected = msg.cardData.correctResrouce == msg.resourceItem;
        Answer answer = msg.cardData.answers.Where(x => x.good == goodSelected && x.resource == msg.resourceItem).FirstOrDefault();
        float amount = answer.cost;
        
        EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithResource(msg.resourceItem).WithFloatMessage(-amount));
    }
}

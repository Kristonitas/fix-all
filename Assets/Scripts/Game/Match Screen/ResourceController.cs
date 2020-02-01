using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    void Start()
    {
        EventCoordinator.StartListening(EventName.System.Economy.ModifyResource(), OnModifyResource);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.Economy.ModifyResource(), OnModifyResource);
    }
    void OnModifyResource(GameMessage msg)
    {
        PlayerDataBucket.AddResource(msg.floatMessage, msg.resourceItem);
        EventCoordinator.TriggerEvent(EventName.System.Economy.ResourceChanged(), GameMessage.Write().WithResource(msg.resourceItem).WithFloatMessage(PlayerDataBucket.GetResource(msg.resourceItem)));
    }
}

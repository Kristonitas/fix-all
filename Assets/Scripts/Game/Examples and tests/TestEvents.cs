using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.KeypadPlus)){
            EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(1.5f).WithResource(ResourceItem.Ductape));
            EventCoordinator.TriggerEvent(EventName.System.Economy.ModifyResource(), GameMessage.Write().WithFloatMessage(-1.5f).WithResource(ResourceItem.Wd));
        }
    }
}

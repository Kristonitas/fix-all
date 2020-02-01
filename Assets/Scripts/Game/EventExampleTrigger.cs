using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExampleTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            EventCoordinator.TriggerEvent(EventName.Input.StartGame(), GameMessage.Write().WithStringMessage("yay"));
        }
    }
}

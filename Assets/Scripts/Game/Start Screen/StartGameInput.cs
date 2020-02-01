using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameInput : MonoBehaviour
{
    public void OnButtonClick()
    {
        EventCoordinator.TriggerEvent(EventName.Input.StartGame(), GameMessage.Write());
    }
}

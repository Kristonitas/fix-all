using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{
    public void InputEditedCallback(string inputName)
    {
        EventCoordinator.TriggerEvent(EventName.Input.PlayerName(), GameMessage.Write().WithStringMessage(inputName));
    }
}

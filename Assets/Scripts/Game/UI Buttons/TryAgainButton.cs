using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public void TryAgainButtonClick(){
        EventCoordinator.TriggerEvent(EventName.Input.ResetGame(), GameMessage.Write());
    }
}

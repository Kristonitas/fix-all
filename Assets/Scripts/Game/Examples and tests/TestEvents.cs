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
        if(Input.GetKeyDown(KeyCode.Keypad1))
            EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(1));
        if(Input.GetKeyDown(KeyCode.Keypad2))
            EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(2));
        if(Input.GetKeyDown(KeyCode.Keypad3))
            EventCoordinator.TriggerEvent(EventName.System.Story.UnlockEnding(), GameMessage.Write().WithIntMessage(3));
        if(Input.GetKeyDown(KeyCode.E))
            EventCoordinator.TriggerEvent(EventName.System.EndGame(), GameMessage.Write());
        if(Input.GetKeyDown(KeyCode.Delete))
            ClearSaves();
    }

    void ClearSaves(){
        PlayerPrefs.SetString("playerName", "");
        PlayerPrefs.SetInt("Ending1", 0);
        PlayerPrefs.SetInt("Ending2", 0);
        PlayerPrefs.SetInt("Ending3", 0);
        PlayerPrefs.Save();

    }
}

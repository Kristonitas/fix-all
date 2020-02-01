using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingLockController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        EventCoordinator.StartListening(EventName.System.Story.UnlockEnding(), OnUnlock);
        EventCoordinator.StartListening(EventName.UI.ShowPostScreen(), OnShow);
        
    }
    void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.System.Story.UnlockEnding(), OnUnlock);
        EventCoordinator.StopListening(EventName.UI.ShowPostScreen(), OnShow);
    }
    void OnUnlock(GameMessage msg)
    {
        switch(msg.intMessage){
            case 0:
                PlayerPrefs.SetInt("Ending1", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("Ending2", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Ending3", 1);
                break;
        }
        PlayerPrefs.Save();
    }
    void OnShow(GameMessage msg){
        Debug.Log("OnShow");
        button1.GetComponent<Locker>().Lock((PlayerPrefs.GetInt("Ending1") > 0));
        button2.GetComponent<Locker>().Lock((PlayerPrefs.GetInt("Ending2") > 0));
        button3.GetComponent<Locker>().Lock((PlayerPrefs.GetInt("Ending3") > 0));
    }
}

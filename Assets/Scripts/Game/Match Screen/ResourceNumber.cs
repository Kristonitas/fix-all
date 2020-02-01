using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceNumber : MonoBehaviour
{
    public ResourceItem resourceItem;
    [SerializeField] TMPro.TextMeshProUGUI text;

    void Start()
    {
        EventCoordinator.StartListening(EventName.System.Economy.ResourceChanged(), OnModifyResource);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.Economy.ResourceChanged(), OnModifyResource);
    }
    void OnModifyResource(GameMessage msg)
    {
        if(resourceItem == msg.resourceItem){
            text.text = msg.floatMessage.ToString();
        }
    }
}

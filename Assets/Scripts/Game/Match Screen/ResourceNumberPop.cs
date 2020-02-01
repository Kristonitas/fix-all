using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNumberPop : MonoBehaviour
{
    public ResourceItem resourceItem;

    [SerializeField] GameObject textGO;

    void Start()
    {
        EventCoordinator.StartListening(EventName.System.Economy.ModifyResource(), OnModifyResource);
    }
    void OnDestroy(){
        EventCoordinator.StopListening(EventName.System.Economy.ModifyResource(), OnModifyResource);
    }
    void OnModifyResource(GameMessage msg)
    {
        if(resourceItem == msg.resourceItem){
            GameObject newTextGO = Instantiate(textGO, transform.parent);
            newTextGO.transform.localPosition = textGO.transform.localPosition;
            TMPro.TextMeshProUGUI tmpText = newTextGO.GetComponent<TMPro.TextMeshProUGUI>();

            NumberPopDissolveFx fx = newTextGO.AddComponent<NumberPopDissolveFx>();
            if(msg.floatMessage < 0){
                tmpText.text = msg.floatMessage.ToString();
                tmpText.color = GameConstantsBucket.ResourceColorNegative;
            }
            else{
                tmpText.text = "+"+msg.floatMessage.ToString();
                tmpText.color = GameConstantsBucket.ResourceColorPositive;
            }
            fx.Init(tmpText);
        }
    }
}

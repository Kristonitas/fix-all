using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBucket : Singleton<PlayerDataBucket>
{
    string playerName = "";
    public float tapeOwned;
    public float wdOwned;
    public static string GetPlayerName(){
        Debug.Log(Instance.playerName);
        return Instance.playerName;
    }
    public static void SetPlayerName(string inuputName){
        Debug.Log(Instance.playerName);
        Instance.playerName = inuputName;
    }
    public static float GetResource(ResourceItem resourceType){
        switch(resourceType){
            case ResourceItem.Ductape:
                return Instance.tapeOwned;
            case ResourceItem.Wd:
                return Instance.wdOwned;
        }
        return 0;
    }
    public static void AddResource(float amount, ResourceItem resourceType){
        switch(resourceType){
            case ResourceItem.Ductape:
                Instance.tapeOwned+=amount;
                break;
            case ResourceItem.Wd:
                Instance.wdOwned+=amount;
                break;
        }
    }
    public static bool IsAnyResourceEmpty(){
        if(Instance.tapeOwned < 0 || Instance.wdOwned < 0)
            return true;
        else
            return false;
    }
}

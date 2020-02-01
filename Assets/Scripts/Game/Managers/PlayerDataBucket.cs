using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBucket : Singleton<PlayerDataBucket>
{
    string playerName;
    public static string GetPlayerName(){
        return Instance.playerName;
    }
    public static void SetPlayerName(string inuputName){
        Instance.playerName = inuputName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{
    string inputName = "";
    void Awake(){
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnStartGame);
        inputName = PlayerPrefs.GetString("playerName");
        if(inputName != ""){
            GetComponentInChildren<TMP_InputField>().text = inputName;
            PlayerDataBucket.SetPlayerName(inputName);
        }
    }
    public void InputEditedCallback(string _inputName)
    {
        Debug.Log("field trigger");
        inputName = _inputName;
            PlayerDataBucket.SetPlayerName(inputName);
    }
    void OnStartGame(GameMessage msg){
        PlayerPrefs.SetString("playerName", inputName);
        PlayerPrefs.Save();
    }
}

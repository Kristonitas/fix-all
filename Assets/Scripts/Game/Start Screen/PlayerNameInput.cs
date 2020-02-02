using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{
    string inputName;
    void Start(){
        EventCoordinator.StartListening(EventName.Input.StartGame(), OnStartGame);
        inputName = PlayerPrefs.GetString("playerName");
        if(inputName != "")
            GetComponentInChildren<TMP_InputField>().text = inputName;
    }
    public void InputEditedCallback(string _inputName)
    {
        inputName = _inputName;
        PlayerDataBucket.SetPlayerName(_inputName);
    }
    void OnStartGame(GameMessage msg){
        PlayerPrefs.SetString("playerName", inputName);
        PlayerPrefs.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{
    public void InputEditedCallback(string inputName)
    {
        PlayerDataBucket.SetPlayerName(inputName);
    }
}

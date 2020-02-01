using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Locker : MonoBehaviour
{
    public GameObject lockPic;
    public void Lock(bool state){
        lockPic.SetActive(!state);
        GetComponent<Button>().interactable = state;
    }
}

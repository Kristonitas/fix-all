using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingTabs : MonoBehaviour
{
    public Transform[] buttons;
    public Animator endingFieldAnimator;
    public Animator actionsFieldAnimator;

    public Transform selectedTab;
    public bool endingsOpen = false;
    public string[] endingTexts = new string[3];
    public TMPro.TextMeshProUGUI text;

    public Color tabActiveColor;
    public Color tabPassiveColor;
    
    void Start()
    {
        
    }

    public void Button(int id){
        ResetTabColor();
        buttons[id].SetAsFirstSibling();
        buttons[id].GetComponent<Image>().color = tabActiveColor;
        if(selectedTab == null){
            selectedTab = buttons[id];
            ChangeFieldState(endingTexts[id]);
        } else {
            if(selectedTab != buttons[id]){
                selectedTab = buttons[id];
                text.text = endingTexts[id];
            }
            else {
                ChangeFieldState(endingTexts[id]);
            }
        }
    }

    public void ChangeFieldState(string showText){
        if(endingsOpen){
            text.text = "";
            endingFieldAnimator.SetBool("open", false);
            actionsFieldAnimator.SetBool("open", true);
            selectedTab = null;
        } else {
            text.text = showText;
            endingFieldAnimator.SetBool("open", true);
            actionsFieldAnimator.SetBool("open", false);
        }

        endingsOpen = !endingsOpen;
    }
    void ResetTabColor(){
        foreach(Transform tr in buttons){
            tr.GetComponent<Image>().color = tabPassiveColor;
        }
    }
}

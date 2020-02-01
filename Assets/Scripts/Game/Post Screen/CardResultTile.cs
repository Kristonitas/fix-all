using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardResultTile : MonoBehaviour
{
    RectTransform rectTr;
    public Image guessedImage;
    public Image resourceImage;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI amountText;

    public Sprite tapeSprite;
    public Sprite wdSprite;
    void Start()
    {
        rectTr = GetComponent<RectTransform>();
        rectTr.sizeDelta = new Vector2(Screen.height / 10f, rectTr.sizeDelta.y);
    }

    public GameObject Create(GuessResult cardResult)
    {
        GameObject resultGo = Instantiate(gameObject);
        CardResultTile newCardRes = resultGo.GetComponent<CardResultTile>();
        newCardRes.guessedImage.sprite = cardResult.imageGuessed;
        newCardRes.resultText.text = cardResult.resultText;
        newCardRes.amountText.text = cardResult.amount;
        if(cardResult.resourceUsed == ResourceItem.Ductape)
            newCardRes.resourceImage.sprite = tapeSprite;
        if(cardResult.resourceUsed == ResourceItem.Wd)
            newCardRes.resourceImage.sprite = wdSprite;
        if(cardResult.correct)
            newCardRes.amountText.color = GameConstantsBucket.ResourceColorPositive;
        else
            newCardRes.amountText.color = GameConstantsBucket.ResourceColorNegative;
        return resultGo;
    }   
}

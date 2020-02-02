using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GuessResult 
{
    public ResourceItem resourceUsed;
    public string amount;
    public Sprite imageGuessed;
    public string resultText;
    public bool correct;
    public GuessResult(CardData data, ResourceItem resource){
        correct = (data.correctResrouce == resource);
        Answer answer = data.answers.Where(x => (x.good == correct) && x.resource == resource).FirstOrDefault();
        float newAmount = answer.cost;
        amount = (Mathf.Round(newAmount * 10f) / 10f).ToString();
        imageGuessed = data.coverImage;
        resultText = answer.text;
        resourceUsed = resource;
    }
}

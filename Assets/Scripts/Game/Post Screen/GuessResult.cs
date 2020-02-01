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
        Answer answer = data.answers.Where(x => x.good && x.resource == resource).FirstOrDefault();
        float newAmount = answer.cost;
        if(newAmount > 0)
            correct = false;
        amount = newAmount.ToString();
        imageGuessed = data.coverImage;
        resultText = answer.text;
        resourceUsed = resource;
    }
}

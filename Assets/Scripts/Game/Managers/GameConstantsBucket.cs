using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstantsBucket : Singleton<GameConstantsBucket>
{
    [Header("Fx")]
    [Tooltip("Text which floats when resources decrease")]
    [SerializeField] Color resourceColorNegative = Color.red;
    public static Color ResourceColorNegative{        get{return Instance.resourceColorNegative;}    }
    [Tooltip("Text which floats when resources increase")]
    [SerializeField] Color resourceColorPositive = Color.green;
    public static Color ResourceColorPositive{        get{return Instance.resourceColorPositive;}    }

    [Range(0,1)]
    [Tooltip("Text floats fade speed")]
    [SerializeField] float numberTextFadeTime = 0.5f;
    public static float NumberTextFadeTime{        get{return Instance.numberTextFadeTime;}    }
    [Range(0,0.1f)]
    [Tooltip("Text floats how much does this slow down over time")]
    [SerializeField] float numberTextFadeSlowdownFactor = 0.002f;
    public static float NumberTextFadeSlowdownFactor{        get{return Instance.numberTextFadeSlowdownFactor;}    }
    [Header("Story")]
    [Range(0,5f)]
    [Tooltip("the multiplier of how many times one resource to guess rigth more than other to get the ending")]
    [SerializeField] float endingResourceMultiplier = 2f;
    public static float EndingResourceMultiplier{        get{return Instance.endingResourceMultiplier;}    }
    [Range(0,10f)]
    [Tooltip("the multiplier of how many times one resource to guess rigth more than other to get the ending")]
    [SerializeField] float endingResourceDifference = 5f;
    public static float EndingResourceDifference{        get{return Instance.endingResourceDifference;}    }
    [Range(0,10f)]
    [Tooltip("how much additional resources the player will have next match if ending is unlocked")]
    [SerializeField] float endingResourceAward = 25f;
    public static float EndingResourceAward{        get{return Instance.endingResourceAward;}    }
    
    [Header("Economy")]
    [Tooltip("wrong reward value = base wrong + randomrange")]
    [SerializeField] float baseWrongAnswerCost = 5f;
    public static float BaseWrongAnswerCost{        get{return Instance.baseWrongAnswerCost;}    }
    [Tooltip("correct reward value = base answer invert - base wrong + randomrange")]
    [SerializeField] float answerCostRandomRange = 1f;
    public static float AnswerCostRandomRange{        get{return Instance.answerCostRandomRange;}    }
    [Tooltip("correct reward value = base answer invert - base wrong + randomrange")]
    [SerializeField] float baseAnswerInvert = 2f;
    public static float BaseAnswerInvert{        get{return Instance.baseAnswerInvert;}    }
}

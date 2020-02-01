using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstantsBucket : Singleton<GameConstantsBucket>
{
    [Header("Colors")]
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
    [Range(0,5f)]
    [Tooltip("the multiplier of how many times one resource to guess rigth more than other to get the ending")]
    [SerializeField] float endingResourceMultiplier = 2f;
    public static float EndingResourceMultiplier{        get{return Instance.endingResourceMultiplier;}    }
    [Range(0,10f)]
    [Tooltip("the multiplier of how many times one resource to guess rigth more than other to get the ending")]
    [SerializeField] float endingResourceDifference = 5f;
    public static float EndingResourceDifference{        get{return Instance.endingResourceDifference;}    }

}

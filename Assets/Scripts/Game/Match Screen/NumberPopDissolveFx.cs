using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPopDissolveFx : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    Color textCol;
    float colorReduce;
    float colorFadeSpeed = 0.02f;
    public void Init(TextMeshProUGUI _text)
    {
        text = _text;
        textCol = text.color;
    }

    void Update()
    {
        transform.position += new Vector3(0, 2.5f * GameConstantsBucket.NumberTextFadeTime, 0);
        colorReduce++;
        if(textCol.a - colorReduce * colorFadeSpeed < 0)
            Destroy(gameObject);
        text.color = new Color(textCol.r, textCol.g, textCol.b, textCol.a - colorReduce * colorFadeSpeed);
    }
}

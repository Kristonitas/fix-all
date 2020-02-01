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
    float speed;
    public void Init(TextMeshProUGUI _text)
    {
        speed = 2.5f * GameConstantsBucket.NumberTextFadeTime;
        text = _text;
        textCol = text.color;
    }

    void Update()
    {
        speed *= (1f-GameConstantsBucket.NumberTextFadeSlowdownFactor);
        transform.position += new Vector3(0, speed, 0);
        colorReduce++;
        if(textCol.a - colorReduce * colorFadeSpeed < 0)
            Destroy(gameObject);
        text.color = new Color(textCol.r, textCol.g, textCol.b, textCol.a - colorReduce * colorFadeSpeed);
    }
}

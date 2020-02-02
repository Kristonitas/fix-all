using System.Collections;
using UnityEngine;
using TMPro;

public class AnswerAnimation : MonoBehaviour
{
    static float Duration = 3;

    public TextMeshPro textMesh;
    public Transform content;

    public void SetAnswer(Answer answer)
    {
        StartCoroutine(Animate(answer));
    }

    IEnumerator Animate(Answer answer)
    {
        float start = Time.time;

        while (Time.time - start < Duration)
        {
            float dt = (Time.time - start) / Duration;

            float y = 1 - Mathf.Clamp01(Mathf.Pow(1 - dt * 1.5f, 3));
            content.localPosition = new Vector3(0, y, 0);

            float alphaIn = Mathf.Clamp01(Mathf.Pow(dt * 6, 3));
            float alphaOut = Mathf.Clamp01(Mathf.Pow(8 - dt * 8, 3));
            textMesh.alpha = Mathf.Min(alphaIn, alphaOut);

            yield return null;
        }

        GameObject.Destroy(gameObject);
    }
}

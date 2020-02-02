using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshPro textMesh;
    public ResultAnimation resultAnimation;

    public Result CreateCard(Answer answer)
    {
        GameObject newResultGO = Instantiate(this.gameObject);
        Result newResult = newResultGO.GetComponent<Result>();
        newResult.textMesh.text = answer.text;
        newResult.textMesh.color = answer.good ? Color.green : Color.red;
        newResult.resultAnimation.SetAnswer(answer);

        return newResult;
    }
}

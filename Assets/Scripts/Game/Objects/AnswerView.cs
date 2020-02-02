using UnityEngine;
using TMPro;

public class AnswerView : MonoBehaviour
{
    public TextMeshPro textMesh;
    public AnswerAnimation answerAnimation;

    public AnswerView CreateCard(Answer answer)
    {
        GameObject newAnswerViewGO = Instantiate(this.gameObject);
        AnswerView newAnswerView = newAnswerViewGO.GetComponent<AnswerView>();
        newAnswerView.textMesh.text = answer.text;
        newAnswerView.textMesh.color = answer.good ? Color.green : Color.red;
        newAnswerView.answerAnimation.SetAnswer(answer);

        return newAnswerView;
    }
}

using UnityEngine;

public class AnswerViewFactory : MonoBehaviour
{
    public AnswerView answerViewPrefab;

    void Start()
    {
        // TEST CODE
        CardImporter.Import();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            answerViewPrefab.CreateCard(CardCoordinator.GetCard(0).answers[0]);
        }
    }
}

using UnityEngine;
using System.Linq;

public class AnswerViewFactory : MonoBehaviour
{
    public AnswerView answerViewPrefab;

    void Start()
    {
        EventCoordinator.StartListening(EventName.Input.CardSelected(), OnCardSelected);
    }

    void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.Input.CardSelected(), OnCardSelected);
    }

    void OnCardSelected(GameMessage msg)
    {
        bool goodSelected = msg.cardData.correctResrouce == msg.resourceItem;
        Answer answer = msg.cardData.answers.Where(x => x.good == goodSelected && x.resource == msg.resourceItem).FirstOrDefault();

        answerViewPrefab.CreateCard(answer);
    }
}

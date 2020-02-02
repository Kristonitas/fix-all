using UnityEngine;

public class ResultFactory : MonoBehaviour
{
    public Result resultPrefab;

    void Start()
    {
        // TEST CODE
        CardImporter.Import();

        resultPrefab.CreateCard(CardCoordinator.GetCard(0).answers[0]);
    }
}

using UnityEngine;

public class CardImporter
{
    private static int RowDuctapeGood = 4;
    private static int RowDuctapeBad = 5;
    private static int RowWdGood = 2;
    private static int RowWdBad = 3;


    private static CardData MakeCard(string[] data)
    {
        Sprite cover = Resources.Load<Sprite>("content pictures/" + data[1]);

        Answer ductapeGood, ductapeBad, wdGood, wdBad;

        ductapeGood = new Answer();
        ductapeGood.resource = ResourceItem.Ductape;
        ductapeGood.good = true;
        ductapeGood.text = data[RowDuctapeGood];
        ductapeGood.cost = CardCoordinator.GetRandomizedReward(ductapeGood);

        ductapeBad = new Answer();
        ductapeBad.resource = ResourceItem.Ductape;
        ductapeBad.good = false;
        ductapeBad.text = data[RowDuctapeBad];
        ductapeBad.cost = CardCoordinator.GetRandomizedReward(ductapeBad);

        wdGood = new Answer();
        wdGood.resource = ResourceItem.Wd;
        wdGood.good = true;
        wdGood.text = data[RowWdGood];
        wdGood.cost = CardCoordinator.GetRandomizedReward(wdGood);

        wdBad = new Answer();
        wdBad.resource = ResourceItem.Wd;
        wdBad.good = false;
        wdBad.text = data[RowWdBad];
        wdBad.cost = CardCoordinator.GetRandomizedReward(wdBad);

        CardData card = new CardData();

        card.answers = new Answer[] { ductapeGood, ductapeBad, wdGood, wdBad };
        card.coverImage = cover;
        return card;
    }

    public static void Import()
    {
        TextAsset tsvText = (TextAsset)Resources.Load("cards");
        string[] records = tsvText.text.Split('\n');
        for (int i = 1; i < records.Length; i++)
        {
            string[] data = records[i].Split('\t');
            CardData card = MakeCard(data);
            CardCoordinator.AddCard(card);
        }
    }
}

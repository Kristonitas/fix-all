using UnityEngine;

public class CardImporter
{
    private static CardData MakeCard(string[] data)
    {
        Sprite cover = Resources.Load<Sprite>(data[1]);

        Answer ductapeGood, ductapeBad, wdGood, wdBad;

        ductapeGood = new Answer();
        ductapeGood.resource = ResourceItem.Ductape;
        ductapeGood.good = true;
        ductapeGood.text = data[2];
        ductapeGood.cost = 1;

        ductapeBad = new Answer();
        ductapeBad.resource = ResourceItem.Ductape;
        ductapeBad.good = false;
        ductapeBad.text = data[3];
        ductapeBad.cost = 1;

        wdGood = new Answer();
        wdGood.resource = ResourceItem.Wd;
        wdGood.good = true;
        wdGood.text = data[4];
        wdGood.cost = 1;

        wdBad = new Answer();
        wdBad.resource = ResourceItem.Wd;
        wdBad.good = false;
        wdBad.text = data[5];
        wdBad.cost = 1;

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

using UnityEngine;
using System.Collections.Generic;
public class GameMessage
{
    public static GameMessage Write()
    {
        return new GameMessage();
    }
    public string strMessage;
    public GameMessage WithStringMessage(string value)
    {
        strMessage = value;
        return this;
    }
    public float floatMessage;
    public GameMessage WithFloatMessage(float value)
    {
        floatMessage = value;
        return this;
    }
    public Vector2 coordinates;
    public GameMessage WithCoordinates(Vector2 value)
    {
        coordinates = value;
        return this;
    }

    public Transform transform;
    public GameMessage WithTransform(Transform value)
    {
        transform = value;
        return this;
    }
    public CardData cardData;
    public GameMessage WithCardData(CardData value)
    {
        cardData = value;
        return this;
    }
    public ResourceItem resourceItem;
    public GameMessage WithResource(ResourceItem value)
    {
        resourceItem = value;
        return this;
    }
}
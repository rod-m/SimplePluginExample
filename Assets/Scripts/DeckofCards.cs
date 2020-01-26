using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using CardGame;

public static class EnumUtil
{
    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

[CreateAssetMenu(menuName = "DeckofCards", fileName = "DeckofCards.asset")]
public class DeckofCards : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Card> deck;
    [NonSerialized] public List<Card> playDeck;

    public void OnAfterDeserialize()
    {
        playDeck = deck;
    }

    public void OnBeforeSerialize()
    {
        GameObject cardPrefab = Resources.Load("cardPrefab") as GameObject;
        deck = new List<Card>();
        int count = 0;
        foreach (var s in EnumUtil.GetValues<CardGame.Suit>())
        {
            foreach (var f in EnumUtil.GetValues<CardGame.Face>())
            {
                Card card = new Card(s, f);
                card.cardPrefab = cardPrefab;
                deck.Add(card);
                count++;
            }
        }
    }
}
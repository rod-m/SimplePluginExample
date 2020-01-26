using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
    [Serializable]
    public enum Suit{Club, Spade, Heart, Diamond}
    [Serializable]
    public enum Face{ Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack=10, Queen=10, King=10}

    [Serializable]
    public class Card
    {
        public string name;
        public Face face;
        public Suit suit;
        public GameObject cardPrefab;

        public Card(Suit _suit, Face _face)
        {
            suit = _suit;
            face = _face;

            SetName();
        }

        public void SetName()
        {
            name = String.Format("{0} of {1}s", face.ToString(), suit.ToString());
        }
    }

}
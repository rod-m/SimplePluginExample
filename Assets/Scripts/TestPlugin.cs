using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame;
[Serializable]
public enum Suit{Club, Spade, Heart, Diamond}
[Serializable]
public enum Face{ Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack=10, Queen=10, King=10}

[ExecuteInEditMode]
public class TestPlugin : MonoBehaviour
{
    /// <summary>
    /// Player Cards
    /// </summary>

    public Card[] playerHand;

   
}

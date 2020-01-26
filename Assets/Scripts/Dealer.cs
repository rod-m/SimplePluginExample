using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;
using Random = System.Random;
using CardGame;

    public class Dealer : MonoBehaviour
    {
        public Transform table;
        public GameObject cardPrefab;
        Random randomCard = new Random();
        public DeckofCards master_deck;
        public DeckofCards[] playerCards;
        public float spacer = 0.5f;
        private int turn = 0;
        public int round = 0;
        public Card[] currentPlayer;
        public int numPlayers = 2;

        private Vector3 pos;

        // Start is called before the first frame update
        void Start()
        {
            playerCards = new DeckofCards[numPlayers];

            for (int i = 0; i < numPlayers; i++)
            {
                playerCards[i] = ScriptableObject.CreateInstance<DeckofCards>();
                playerCards[i].playDeck = new List<Card>();
            }

            pos = new Vector3(table.position.x, table.position.y, table.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                int r = randomCard.Next(master_deck.playDeck.Count);
                //Debug.Log(String.Format("Random card {0} turn {1}", r, turn));
                playerCards[turn].playDeck.Add(master_deck.playDeck[r]);
                master_deck.playDeck.RemoveAt(r);
                List<Card> deck = playerCards[turn].playDeck;

                currentPlayer = deck.ToArray();
                turn++;



                pos.y = table.position.y + turn;
                //Debug.Log(pos.ToString() + " " + spacer);
                GameObject c = Instantiate(cardPrefab, pos, Quaternion.identity);
                c.SendMessage("SetCardNum", r);
                if (turn >= numPlayers)
                {
                    round++;
                    turn = 0;
                    pos.x += spacer;
                    Debug.Log(String.Format("round {0}", round));
                }

            }
        }
    }

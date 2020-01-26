using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    private Animator anim;
     float cardFrame = 0f;
    public int cardNum = 0;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0f;
        cardFrame = 52f / cardNum;
        anim.Play("DeckOfCards",0,cardFrame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardNum(int _num)
    {
        cardNum = _num;
        cardFrame = cardNum / 52f;
        anim.Play("DeckOfCards",0,cardFrame);
    }
}

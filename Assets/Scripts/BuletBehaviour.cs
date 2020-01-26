using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletBehaviour : MonoBehaviour
{
    private int damage {
        get {
            return bulletConfig.damage;
        }
    }

    private float speed {
        get {
            return bulletConfig.speed;
        }
    }

    public BulletConfig bulletConfig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Statuses
{
    BallOStart,
    BallInField,
}

public class Ball : MonoBehaviour
{
    private Statuses statuse;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(2f, 8f), Random.Range(2f, 8f));
    }

    void Awake()
    {
        statuse = Statuses.BallOStart;
    }

    public void Move()
    {
       
       
    }
}

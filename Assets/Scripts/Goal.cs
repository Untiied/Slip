using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject State;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            State.GetComponent<GameState>().LevelFinished = true;
            Debug.Log("Hit Goal");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}

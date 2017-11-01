using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocker : MonoBehaviour {

    public float Health;
    public TextMesh HealthLabel;

    private void Awake()
    {
        Health = Random.Range(2,8);
        UpdateText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health--;
            UpdateText();
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void UpdateText()
    {
        HealthLabel.text = Health.ToString();
    }
}

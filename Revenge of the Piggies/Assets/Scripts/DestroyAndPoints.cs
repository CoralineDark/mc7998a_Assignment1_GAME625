using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndPoints : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            ScoreScript.scoreValue = ScoreScript.scoreValue + 1;
            Destroy(gameObject);
        }
    }
}

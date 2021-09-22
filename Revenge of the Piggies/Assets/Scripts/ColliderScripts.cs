using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScripts : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Structure") {
            if (this.GetComponent<Rigidbody2D>().gravityScale == 0) {
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
            } 
        }

        if (other.gameObject.tag == "Ground") { 
            ScoreScript.scoreValue = ScoreScript.scoreValue + 1;
        }
    }
}

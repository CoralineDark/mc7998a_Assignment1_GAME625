using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScripts : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Structure" && other.gameObject.gameObject.tag != "immobileStructure") {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if (this.GetComponent<Rigidbody2D>().gravityScale == 0) {
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
            } 
        }
    }
}

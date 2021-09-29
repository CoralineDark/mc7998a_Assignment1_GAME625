using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour
{
    public GameObject explosion; 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);     
        }
    }
}

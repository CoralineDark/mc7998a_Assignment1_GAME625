using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakChain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            gameObject.GetComponent<HingeJoint2D>().connectedBody= null; 
        }
    }
}

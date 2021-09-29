using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player; 
    private float speed = 2.0f; 
    // Update is called once per frame
    private void Start() { 
        player = GameObject.FindWithTag("Player"); 
    }
    
    void Update()
    {
        if(player == null) {
            player = GameObject.FindWithTag("Player");
        }
        if (player.transform.parent != null) {
            float interpolation = speed * Time.deltaTime; 
            Vector3 position = this.transform.position; 
            position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x+8, interpolation);
            position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
            this.transform.position = position; 
        } else {
            float interpolation = speed * Time.deltaTime; 
            Vector3 position = this.transform.position; 
            position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
            position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
            this.transform.position = position; 
        }
    }
}

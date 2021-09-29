using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    private float interval = 1.5f;
    void Update()
    {
        if (interval > 0) {
                interval -=Time.deltaTime; 
        } else { 
            Destroy(gameObject);    
        }
    }
}

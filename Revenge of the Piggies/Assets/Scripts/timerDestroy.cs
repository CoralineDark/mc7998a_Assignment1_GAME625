using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerDestroy : MonoBehaviour
{
    float interval = 5; 
    bool piggieLaunched;
    public Transform piggieReload;  
    // Start is called before the first frame update
    void Start()
    {
        piggieLaunched = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent == null) {
            if (interval > 0) {
                    interval -=Time.deltaTime; 
            } else { 
                killPiggie(); 
            }
        }
    }

    void killPiggie() { 
        GameObject.Find("Cannon").GetComponent<CannonBehavoirs>().spawnNewPiggie(); 
        interval = 5;
        Destroy(gameObject);
    }
}

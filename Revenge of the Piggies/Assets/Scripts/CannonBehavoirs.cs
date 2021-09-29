using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavoirs : MonoBehaviour
{
    private bool piggieLaunched; 
    private const float MAX_ANGLE = 80.0f; 
    private const float MIN_ANGLE = 10.0f;  
    public Rigidbody2D piggie;
    public Transform piggieReload; 
    public Camera camera;
    public GameObject piggiePrefab; 
    public GameObject piggieParent; 
  
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        piggie.gravityScale = 0;
        piggieLaunched = false;  
    }
    void Update()
    {
        if (piggie == null) {
            spawnNewPiggie(); 
        }
        Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);
        Vector3 mouseInWorld = camera.ScreenToWorldPoint(pointInWorld); 
        Vector3 temp = mouseInWorld - transform.position; 
        Vector2 dirAndMag = new Vector2(temp.x, temp.y);
        float angleOfCannon = Mathf.Acos(Vector3.Dot (Vector3.right, dirAndMag.normalized))*Mathf.Rad2Deg;
        if (angleOfCannon <= MAX_ANGLE && angleOfCannon > MIN_ANGLE && dirAndMag.y > 0) {
            transform.rotation = Quaternion.Euler(0,0,angleOfCannon);
        }
        //transform.LookAt(mouseInWorld); 
        
        if (Input.GetMouseButton(0) && !piggieLaunched) {
            piggie.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; 
            piggieLaunched = true; 
            piggie.gravityScale = 1;
            piggie.transform.parent = null; 
            piggie.AddForce(100*dirAndMag);    
        }
    }

    public void resetLauncher() {
        piggieLaunched = false; 
    }
    public void spawnNewPiggie() { 
        GameObject newPiggie = Instantiate(piggiePrefab, piggieReload.transform.position, piggieReload.transform.rotation, piggieParent.transform);  
        newPiggie.tag = "Player";
        piggie = newPiggie.GetComponent<Rigidbody2D>(); 
        piggieLaunched = false;
        piggie.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}

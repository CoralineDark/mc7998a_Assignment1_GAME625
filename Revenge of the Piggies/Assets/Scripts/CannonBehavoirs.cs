using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavoirs : MonoBehaviour
{
    private bool piggieLaunched; 
    private int MAX_ANGLE = 80; 
    private int MIN_ANGLE = 20;  
    public Rigidbody2D piggie;
    public Transform piggieReload; 
    public Camera camera;
    public GameObject piggiePrefab; 
    public GameObject piggieParent; 
  
    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        piggie.gravityScale = 0;
        piggieLaunched = false;  
    }
    void Update()
    {
        //if (piggie == null) {
        //    spawnNewPiggie(); 
        //}
        Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);
        Vector3 mouseInWorld = camera.ScreenToWorldPoint(pointInWorld); 
        Vector3 temp = mouseInWorld - transform.position; 
        Vector2 dirAndMag = new Vector2(temp.x, temp.y);
        transform.LookAt(mouseInWorld); 
        if (Input.GetMouseButton(0) && !piggieLaunched) {
            piggieLaunched = true; 
            piggie.gravityScale = 1;
            piggie.transform.parent = null; 
            piggie.AddForce(100*dirAndMag); 
        }
    }

    public void resetLauncher() {
        piggieLaunched = false; 
    }
    /*public void spawnNewPiggie() { 
        GameObject newPiggie = Instantiate(piggiePrefab, piggieReload.transform.position, piggie.transform.rotation, piggieParent.transform);  
        newPiggie.tag = "Player";
        piggie = newPiggie.GetComponent<Rigidbody2D>(); 
    }*/
}

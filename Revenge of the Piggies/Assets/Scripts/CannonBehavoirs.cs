using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavoirs : MonoBehaviour
{
    private bool piggieLaunched; 
    private int MAX_ANGLE = 80; 
    private int MIN_ANGLE = 20; 
    float force; 
    float torque; 
    public Rigidbody2D piggie; 
    public Camera camera;
    private int piggieCount; 
    public Transform piggie_reload; 
    public GameObject cannon_Sprite;  
    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        cannon_Sprite = GameObject.Find("Cannon_Sprite");
        piggie.gravityScale = 0;
        piggieLaunched = false;
        piggieCount = 10; 
    }
    void Update()
    {
        Vector3 pointInWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);
        Vector3 mouseInWorld = camera.ScreenToWorldPoint(pointInWorld); 
        Vector3 temp = mouseInWorld - transform.position; 
        Vector2 dirAndMag = new Vector2(temp.x, temp.y);
        transform.LookAt(mouseInWorld); 
        if (Input.GetMouseButton(0)) {
            piggieCount--; 
            piggieLaunched = true; 
            piggie.gravityScale = 1;
            piggie.transform.parent = null; 
            piggie.AddForce(100*dirAndMag); 
            spawnNewPiggie(); 
        }
    }

    public void spawnNewPiggie() { 
        piggie.gravityScale = 0; 
        piggie.transform.parent = cannon_Sprite.transform; 
        piggie = Instantiate(piggie, piggie_reload.position, piggie_reload.rotation); 
    }
}

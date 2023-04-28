using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private int speed = 10;
    public Camera camera;

    private bool DisableZ;

    // Start is called before the first frame update
    void Start()
    {
        DisableZ = false;
    }

    // Update is called once per frame
    void Update()
     {
     if(Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
     }
     if(Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
     }
     if(Input.GetKey(KeyCode.Z))
     {
         camera.fieldOfView *= 1.002f;
     }
     if(Input.GetKey(KeyCode.X))
     {
         camera.fieldOfView *= 0.998f;
     }
     if (Input.GetKey(KeyCode.Z) & (camera.fieldOfView == 8.65415f)); 
     {
        DisableZ = false;
     }
    }
}

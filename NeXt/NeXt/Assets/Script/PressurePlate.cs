using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    
    public Transform obj1;
    public GameObject player;
    public Transform target;
    public GameObject Door;
    private bool isPressed = false;
    public float speed;



    // Update is called once per frame
    void Update ()
    {
        if ((obj1.transform.position - player.transform.position).magnitude < 1.0f)
        {
            float step = speed * Time.deltaTime;
            Door.transform.position = Vector3.MoveTowards(Door.transform.position, target.position, step);
        }
    }
}

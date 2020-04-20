using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject[] players;
    public Transform Plate;
    public GameObject Door;
    public float moveOnX;
    public float moveOnY;
    private bool isPressed = false;
    public float speed;
    private Vector3 oldPos;
    private bool activePlate;
    private int count;

    void Start()
    {
        oldPos = new Vector3(Door.transform.position.x, Door.transform.position.y);
    }


    // Update is called once per frame
    void Update ()
    {
        count = -1;
        float step = speed * Time.deltaTime;
        foreach (GameObject player in players)
        {
            if ((Plate.transform.position - player.transform.position).magnitude < 1.5f)
            {
                activePlate = true;
                Door.transform.position = Vector3.MoveTowards(Door.transform.position, new Vector3(oldPos.x + moveOnX, oldPos.y + moveOnY, Door.transform.position.z), step);
            }
            else
            {
                if(!(player.GetComponent<PlayerController>().getActivePlayer() && ((Plate.transform.position - player.transform.position).magnitude < 1.5f)) && !activePlate)
                {
                    Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos, step);
                }
                else if(count == -1)
                {
                    activePlate = false;
                }
            }

            if((Plate.transform.position - player.transform.position).magnitude < 1.5f)
            {
                count++;
            }
        }
    }

    public void setOldPos()
    {
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, oldPos , 1000000);
    }
}

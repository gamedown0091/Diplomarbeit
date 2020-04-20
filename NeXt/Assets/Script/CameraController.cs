using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject[] players;
    private int activePlayer = 0;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - players[activePlayer].transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = players[activePlayer].transform.position + offset;
	}

    public void setPlayer()
    {
        activePlayer++;
    }
}

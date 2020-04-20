using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeRift : MonoBehaviour {

    //public ActionSaveList saveList;
    public GameObject[] schalter;
    public GameObject Camera;
    public GameObject[] players;
    public Bewegungsspeicher movementSave;
    public float timer;
    public Text timerText;
    private ArrayList restartMovementSave = new ArrayList();
    private int count = 0;
    private float posX = 0;
    private float posY = 0;
    private int playerCount = 0;
    private int restartCount = 0;
    private int activePlayer = 0;
    private float timerValue;


    // Use this for initialization
    void Start ()
    {
        timerValue = timer;
        int counter = 0;
        foreach (GameObject player in players)
        {
            if (activePlayer == counter)
            {
                player.GetComponent<PlayerController>().setActivePlayer(true);
                player.GetComponent<BoxCollider2D>().enabled = true;
                player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
            else
            {
                player.GetComponent<PlayerController>().setActivePlayer(false);
                player.GetComponent<BoxCollider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            }
            counter++;
        }
        
        movementSave = new Bewegungsspeicher();
        movementSave.addBewegung(new Bewegung(new Koordinate(0, 0), new Koordinate(0, 0)));
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        timer = timer - Time.fixedDeltaTime;
        timerText.text = ((int)timer).ToString();

        if (restartMovementSave.Count >= 1)
        {
            int restartedPlayer = 0;
            foreach(Bewegungsspeicher bewegungsspeicher in restartMovementSave)
            {
                if (bewegungsspeicher.getBewegung(count) != null)
                {
                    players[restartedPlayer].transform.position = new Vector3(bewegungsspeicher.getBewegung(count).getEndPos().getX(), bewegungsspeicher.getBewegung(count).getEndPos().getY());
                }
                else
                {

                }
                restartedPlayer++;
            }
            count++;
        }
        
        movementSave.addBewegung(new Bewegung(new Koordinate(posX, posY), new Koordinate(players[playerCount].transform.position.x, players[playerCount].transform.position.y)));
        posX = players[playerCount].transform.position.x;
        posY = players[playerCount].transform.position.y;

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if((playerCount + 1) > (players.Length -1))
            {

            }
            else
            {
                Camera.GetComponent<CameraController>().setPlayer();
                restart();
            }
        }

        if(timer <= 0.0f)
        {
            if ((playerCount + 1) > (players.Length - 1))
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Camera.GetComponent<CameraController>().setPlayer();
                restart();
            }
            
        }
    }

    private void restart()
    {
        timer = timerValue;
        Camera.transform.position = new Vector3(0, 0);
        restartMovementSave.Add(movementSave);
        posX = 0;
        posY = 0;
        count = 0;
        restartCount++;
        playerCount++;
        movementSave = new Bewegungsspeicher();
        movementSave.addBewegung(new Bewegung(new Koordinate(0, 0), new Koordinate(0, 0)));
        activePlayer++;
        int counter = 0;
        foreach (GameObject schalter in schalter)
        {
            schalter.GetComponent<PressurePlate>().setOldPos();
        }
        foreach (GameObject player in players)
        {
            if (activePlayer == counter)
            {
                player.GetComponent<PlayerController>().setActivePlayer(true);
                player.GetComponent<BoxCollider2D>().enabled = true;
                player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
            else
            {
                player.GetComponent<PlayerController>().setActivePlayer(false);
                player.GetComponent<BoxCollider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            }
            counter++;
        }
    }
}

public class Bewegungsspeicher
{
    private ArrayList bewegungslist = new ArrayList();

    public void addBewegung(Bewegung bewegung)
    {
        bewegungslist.Add(bewegung);
    }

    public Bewegung getBewegung(int zahl)
    {
        if ((bewegungslist.Count - 1) >= zahl)
        {
            return (Bewegung) bewegungslist[zahl];
        }

        return null;
    }

    public ArrayList getArray()
    {
        return bewegungslist;
    }
}

public class Bewegung
{
    private Koordinate startPos;
    private Koordinate endPos;
    private Koordinate bewegung;

    public Bewegung(Koordinate startPos, Koordinate endPos)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        makeBewegung();
    }

    private void makeBewegung()
    {
        bewegung = new Koordinate(this.endPos.getX() - this.startPos.getX(), this.endPos.getY() - this.startPos.getY());
    }

    public Koordinate getBewegung()
    {
        return bewegung;
    }

    public Koordinate getEndPos() { return endPos; }
}

public class Koordinate
{
    private float x;
    private float y;

    public Koordinate(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float getX()
    {
        return this.x;
    }

    public float getY()
    {
        return this.y;
    }
}


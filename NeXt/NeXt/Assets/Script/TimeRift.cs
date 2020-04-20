using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRift : MonoBehaviour {
    
    //public ActionSaveList saveList;
    public Bewegungsspeicher movementSave;
    private ArrayList restartMovementSave = new ArrayList();
    private int count = -1;
    private float posX = 0;
    private float posY = 0;
    private int playerCount = 0;
    private int restartCount = -1;
    public GameObject player;

    // Use this for initialization
    void Start () {
        restartMovementSave.Add(movementSave);
        count = -1;
        restartCount++;
        playerCount++;
        movementSave = new Bewegungsspeicher();
        movementSave.addBewegung(new Bewegung(new Koordinate(0, 0), new Koordinate(0, 0)));
    }

    // Update is called once per frame
    void Update () {
        if (restartMovementSave.Count >= 1)
        {
            int restartedPlayer = 0;
            foreach(Bewegungsspeicher bewegungsspeicher in restartMovementSave)
            {
                restartedPlayer++;
                if (bewegungsspeicher.getBewegung(count) != null)
                {
                }
                else
                {

                }
            }
        }

        movementSave.addBewegung(new Bewegung(new Koordinate(posX, posY), new Koordinate(player.transform.position.x, player.transform.position.y)));
        posX = player.transform.position.x;
        posY = player.transform.position.y;
    }

    private void restart()
    {
        restartMovementSave.Add(movementSave);
        posX = 0;
        posY = 0;
        count = -1;
        restartCount++;
        playerCount++;
        movementSave = new Bewegungsspeicher();
        movementSave.addBewegung(new Bewegung(new Koordinate(0, 0), new Koordinate(0, 0)));
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


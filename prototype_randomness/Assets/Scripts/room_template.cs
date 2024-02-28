using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_template : MonoBehaviour
{
    public GameObject[] upperRoom;
    public GameObject[] downRoom;
    public GameObject[] leftRoom;
    public GameObject[] rightRoom;

    public GameObject closedroom;
    public List<GameObject> rooms;

    public float waitTime;
    private bool spawned_end;
    public GameObject End;
    
    void Update()
    {
        if (waitTime <= 0 && spawned_end == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if( i == (rooms.Count - 1))
                {
                    Instantiate(End, rooms[i].transform.position, Quaternion.identity);
                        spawned_end = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}

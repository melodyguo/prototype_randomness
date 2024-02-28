using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_spawner : MonoBehaviour
{
    public int openDirection;
    //1 down
    //2 upper
    //3 left
    //4 right

    private room_template templates;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<room_template>();
        Invoke("Spawn", 1.0f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openDirection == 1)
            {
                rand = Random.Range(0, templates.downRoom.Length);
                Instantiate(templates.downRoom[rand], transform.position, templates.downRoom[rand].transform.rotation);
            }
            else if (openDirection == 2)
            {
                rand = Random.Range(0, templates.upperRoom.Length);
                Instantiate(templates.upperRoom[rand], transform.position, templates.upperRoom[rand].transform.rotation);
            }
            else if (openDirection == 3)
            {
                rand = Random.Range(0, templates.leftRoom.Length);
                Instantiate(templates.leftRoom[rand], transform.position, templates.leftRoom[rand].transform.rotation);
            }
            else if (openDirection == 4)
            {
                rand = Random.Range(0, templates.rightRoom.Length);
                Instantiate(templates.rightRoom[rand], transform.position, templates.rightRoom[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawn"))
        {
            if (other.GetComponent<room_spawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedroom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}


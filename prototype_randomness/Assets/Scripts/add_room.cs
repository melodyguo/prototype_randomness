using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_room : MonoBehaviour
{
    private room_template templates;
    public GameObject torchPrefab;
    
    void Start()
    {
        // random chance of spawning a torch object in the center
        if (Random.Range(0, 10) == 1)
        {
            if (torchPrefab)
            {
                Instantiate(torchPrefab, this.gameObject.transform);
            }
        }
        
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<room_template>();
        templates.rooms.Add(this.gameObject);
    }

}

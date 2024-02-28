using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_room : MonoBehaviour
{
    private room_template templates;
    
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<room_template>();
        templates.rooms.Add(this.gameObject);
    }

}

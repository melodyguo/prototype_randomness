using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win_condition : MonoBehaviour
{
    private bool winplayed = false; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (winplayed) return;
        
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Win();
            winplayed = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win_condition : MonoBehaviour
{
    [SerializeField] private Image customImage;
    AudioSource audios;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
            audios.Play();
        }
    }
}

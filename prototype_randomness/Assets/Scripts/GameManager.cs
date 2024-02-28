using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timer;
    public TMP_Text timerText;
    public GameObject player;
    public Vector3 spawnOffset = new Vector3(0.09f, -0.25f, 0f);
    public GameObject roomSpawner;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Ensure there is only one instance of the GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timerText.text = Mathf.Ceil(timer).ToString();
        Instantiate(roomSpawner, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // update timer
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();
        if (timer <= 0)
        {
            // todo: death
        }
        
        // restart when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void Reshuffle()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");
        foreach (GameObject room in rooms)
        {
            Destroy(room);
        }
        Instantiate(roomSpawner, player.gameObject.transform.position - spawnOffset, Quaternion.identity); 
    }
}

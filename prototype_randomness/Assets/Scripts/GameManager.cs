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
    
    void Awake()
    {
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
}

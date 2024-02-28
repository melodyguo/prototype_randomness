using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject player;
    public Vector3 spawnOffset = new Vector3(0.09f, -0.25f, 0f);
    public GameObject roomSpawner;
    public AudioSource reshuffleSFX;
    public GameObject background;
    public AudioSource jumpscareSFX;
    public GameObject jumpscare;
    
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
        jumpscare.SetActive(false);
        Instantiate(roomSpawner, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // restart when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void Reshuffle()
    {
        reshuffleSFX.Play();
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");
        foreach (GameObject room in rooms)
        {
            Destroy(room);
        }
        Instantiate(roomSpawner, player.gameObject.transform.position - spawnOffset, Quaternion.identity);
        background.transform.position = player.gameObject.transform.position - spawnOffset;
    }

    public void JumpScare()
    {
        StartCoroutine(PlayJumpScare());
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator PlayJumpScare()
    {
        jumpscareSFX.Play();
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        jumpscare.SetActive(false);
        jumpscareSFX.Stop();
    }
}

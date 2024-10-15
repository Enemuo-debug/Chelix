using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // state thy variables 
    private Rigidbody playerRb;
    private float jumpForce = 4;
    public GameObject EndScene;
    private int minusScore = -2;
    private bool ignoreNextCollision;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AllowCollision () {
        ignoreNextCollision = false;
    }
     private void OnCollisionEnter(Collision collision)
     {
        if (ignoreNextCollision) {
            return;
        }
        if (collision.gameObject.CompareTag("Goal") && !ignoreNextCollision)
{
    Debug.Log("Next Level Called");
    playerRb.velocity = Vector3.zero;
    minusScore = 0;
    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    
    EndScene.SetActive(true);
    
    int currentScore = GameManager.singleton.score;
    int bestScore = PlayerPrefs.GetInt("Record", 0);
    int secondBestScore = PlayerPrefs.GetInt("Record1", 0);
    int thirdBestScore = PlayerPrefs.GetInt("Record2", 0);

    if (currentScore > bestScore)
    {
        PlayerPrefs.SetInt("Record2", secondBestScore);
        PlayerPrefs.SetInt("Record1", bestScore);
        PlayerPrefs.SetInt("Record", currentScore);
        GameManager.singleton.bestScore = currentScore;
    }
    else if (currentScore > secondBestScore)
    {
        PlayerPrefs.SetInt("Record2", secondBestScore);
        PlayerPrefs.SetInt("Record1", currentScore);
    }
    else if (currentScore > thirdBestScore)
    {
        PlayerPrefs.SetInt("Record2", currentScore);
    }

    PlayerPrefs.Save();
}
        if (collision.gameObject.CompareTag("Respawn") && !ignoreNextCollision && collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.black) {
            // Go TO Next Level
            Debug.Log("Game Ended");
            GameManager.singleton.AddScore(minusScore);
        }
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        ignoreNextCollision  = true;

        Invoke("AllowCollision", 0.2f);
     }
}

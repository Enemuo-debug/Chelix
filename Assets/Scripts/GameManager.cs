using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    private RewardedAds adsManager;
    public GameObject Helix;
    public GameObject Goal;
    public int score;
    public int bestScore;
    public TextMeshProUGUI scoreText;
    public  TextMeshProUGUI bestText;
   

    private string gameId;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null) {
            singleton = this;
        } else if (singleton != this) {
            Destroy(gameObject);
        }
        bestScore = PlayerPrefs.GetInt("Record");
        bestText.text = $"Standing Record {bestScore}";
        Vector3 currentPosition = Helix.transform.position;
        for (int i = 0; i <= 7; i++) {
            Helix.transform.Rotate(new Vector3(Helix.transform.rotation.x, Random.Range(0, 180), Helix.transform.rotation.z));
            Instantiate(Helix, new Vector3(Helix.transform.position.x, Helix.transform.position.y - (2 * i), Helix.transform.position.z), Helix.transform.rotation);
            Helix.transform.position = currentPosition;
        }
    }

    void Start () 
    {
        adsManager = FindObjectOfType<RewardedAds>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore (int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
        bestText.text = $"Standing Record {bestScore}";
    }

    public void OpenMenu () {
        SceneManager.LoadScene(0);
    }
    public void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

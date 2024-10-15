using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI First;
    public TextMeshProUGUI Second;
    public TextMeshProUGUI Third;


    void Start()
    {
        First.text = "First Position: " +Convert.ToString(PlayerPrefs.GetInt("Record"));
        Second.text = "Second Position: " +Convert.ToString(PlayerPrefs.GetInt("Record"));
        Third.text = "Third Position: " +Convert.ToString(PlayerPrefs.GetInt("Record"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

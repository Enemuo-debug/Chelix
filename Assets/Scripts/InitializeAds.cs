using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string iosGameId;
    [SerializeField] private string androidGameId;
    [SerializeField] private bool isTesting;
    private string gameId;

    public void OnInitializationComplete()
    {
        // throw new System.NotImplementedException();
        System.Console.WriteLine("Success");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        // throw new System.NotImplementedException();
        System.Console.WriteLine("Failed");
    }

    void Awake()
    {
        #if UNITY_IOS
            gameid = iosGameId;
        #elif UNITY_ANDROID
            gameId = androidGameId;
        #elif UNITY_EDITOR
            gameId = androidGameId;
        #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported) {
            Advertisement.Initialize(gameId, isTesting, this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

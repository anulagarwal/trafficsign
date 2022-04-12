using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdManager : MonoBehaviour
{

    public static AdManager Instance = null;

    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Appodeal.initialize("0d93393c93168da6fbc941d147d83a0be804d5ec706ef7fa", Appodeal.BANNER_HORIZONTAL_SMART, true);       
        Appodeal.show(Appodeal.BANNER_BOTTOM);
        Appodeal.isLoaded(Appodeal.BANNER);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

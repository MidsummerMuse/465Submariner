using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject TitleScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideTitleScreen()
    {
        TitleScreen.SetActive(false); //turn off title screen
    }

    public void ShowTitleScreen()
    {
        TitleScreen.SetActive(true); //turn on title screen
    }
}

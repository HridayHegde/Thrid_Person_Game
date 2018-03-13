using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuManager : MonoBehaviour {
    public GameObject MainMenuUI;
    public GameObject AboutUI;
    public bool AboutUIBool = false;
	// Use this for initialization
	void Start () {
        MainMenuUI.SetActive(true);
        AboutUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void AboutGame()
    {
        AboutUIBool = !AboutUIBool;
        if (AboutUIBool)
        {
            AboutUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }
        else
        {
           
            MainMenuUI.SetActive(false);
            AboutUI.SetActive(true);
        }
        

    }
}

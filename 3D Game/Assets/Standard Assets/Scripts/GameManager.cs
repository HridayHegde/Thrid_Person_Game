using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public Player_Movement P_Movement;
    public Player_Sword P_Sword;
    public Camera_Movement Cam_Move;
    public Random_Player_Systems R_P_Systems;
    public P_CombatSystem P_C_System;
    public Testing P_TestSystems;
    public P_Health_Mana_System P_Status;

    public GameObject Player;

    #region ControlsUI
    public GameObject ControlsUI;
    public GameObject ControlsUI2;
    public GameObject ContolsUIHelper;
    public bool ControlUIActive;
    #endregion

    #region PauseMenu
    public bool Pause;
    public GameObject MainUI;
    public GameObject HealthUI;
    public GameObject PauseUI;
    public GameObject MainCamera;
    public GameObject PostProcessingCam;
    #endregion


    // Use this for initialization
    void Awake()
    {
        SetReferences();
        Time.timeScale = 1f;
        MainUI.SetActive(true);
        HealthUI.SetActive(true);
        PauseUI.SetActive(false);
        MainCamera.SetActive(true);
        PostProcessingCam.SetActive(false);
        Pause = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowControls();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void Quit()
    {
        Application.Quit();

    }

    void SetReferences()
    {
        Player = GameObject.FindWithTag("Player");
        P_Movement = Player.GetComponent<Player_Movement>();
        P_Sword = Player.GetComponent<Player_Sword>();
        Cam_Move = Player.GetComponent<Camera_Movement>();
        R_P_Systems = Player.GetComponent<Random_Player_Systems>();
        P_TestSystems = Player.GetComponent<Testing>();
        P_Status = Player.GetComponent<P_Health_Mana_System>();
    }

    public void ShowControls()
    {
        ControlUIActive = !ControlUIActive;
        ControlsUI.SetActive(ControlUIActive);
        ControlsUI2.SetActive(ControlUIActive);
        ContolsUIHelper.SetActive(!ControlUIActive);
    }

    public void PauseGame()
    {
        if (Pause == false)
        {
            Time.timeScale = 0f;
            MainUI.SetActive(false);
            HealthUI.SetActive(false);
            PauseUI.SetActive(true);
            MainCamera.SetActive(false);
            PostProcessingCam.transform.position = MainCamera.transform.position;
            PostProcessingCam.transform.rotation = MainCamera.transform.rotation;
            PostProcessingCam.SetActive(true);
            
            Pause = true;
            
        }
        else
        {
            Time.timeScale = 1f;
            MainUI.SetActive(true);
            HealthUI.SetActive(true);
            PauseUI.SetActive(false);
            MainCamera.SetActive(true);
            PostProcessingCam.SetActive(false);
            Pause = false;
        }
        

    }

    public void GotoMainmenu()
    {
        SceneManager.LoadScene(0);
    }

    





}


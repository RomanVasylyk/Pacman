using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenuScript : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelMenuPanel;
    private int maxlevel = 7;
    private static bool firstStart = true;


    void Start()
    {
        if (!firstStart) 
        {
            nastavLevelMenu();
            
        }
        else
        {
            levelMenuPanel.SetActive(false);
            firstStart = false; 
            
        }
        
    }

    void Update()
    {
        
    }
    private void nastavLevelMenu() {
     mainMenuPanel.SetActive(false);
     levelMenuPanel.SetActive(true);
     int highestLevel = PlayerPrefs.GetInt("level", 1);
     Debug.Log("Highest Level: " + highestLevel);
     if (PlayerPrefs.HasKey("level")) {
         highestLevel = PlayerPrefs.GetInt("level");
     } else {
         PlayerPrefs.SetInt("level", 1);
     }
     
     for(int i = 2; i <= maxlevel; i++) { 
         GameObject myObject = GameObject.Find("lvl"+i+" (1)");
         if (myObject != null) {
             if (i <= highestLevel) {
                 myObject.SetActive(false);
             } else {
                 myObject.SetActive(true);
            }
         } else {
             Debug.Log("lvl"+i+" (1)");
         }
         Debug.Log("Button "+ i + " Active: " + myObject.activeSelf);
     }
 }

    public void spracujKliknutie(int buttonNo) {
        Debug.Log("Button clicked = " + buttonNo);
        SceneManager.LoadScene("lvl" + buttonNo);
        
     }
     public void zobrazMenuLevel() {
         mainMenuPanel.SetActive(false);

          nastavLevelMenu();
     }
     public void zobrazMenuMain() {
         levelMenuPanel.SetActive(false); mainMenuPanel.SetActive(true); 
     }
    public void TogglePanels()
    {
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        levelMenuPanel.SetActive(!levelMenuPanel.activeSelf);
    }
    public void end(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
     

}

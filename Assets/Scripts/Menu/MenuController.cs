using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject difficultyMenu;
    [SerializeField] private GameObject helpMenu;
    
    [SerializeField] private Button playbtn;
    [SerializeField] private Button helpbtn;
    [SerializeField] private Button backbtn;
    [SerializeField] private Button easybtn;
    [SerializeField] private Button mediumbtn;
    [SerializeField] private Button hardbtn;
    
    void Start()
    {
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        helpMenu.SetActive(false);
        playbtn.onClick.AddListener(()=>goDifficultyMenu());
        helpbtn.onClick.AddListener(()=>goHelpMenu());
        backbtn.onClick.AddListener(()=>goBackMenu());


        easybtn.onClick.AddListener(()=>easyMode());
        mediumbtn.onClick.AddListener(()=>mediumMode());
        hardbtn.onClick.AddListener(()=>hardMode());
    }

    public void goDifficultyMenu(){
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(true);
        helpMenu.SetActive(false);
    }
    public void goHelpMenu(){
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(false);
        helpMenu.SetActive(true);
    }
    public void goBackMenu(){
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        helpMenu.SetActive(false);
    }
    public void easyMode(){
        PlayerPrefs.SetInt("Difficulty",1);
        goGameScene();
        
    }
    public void mediumMode(){
        PlayerPrefs.SetInt("Difficulty",2);
        goGameScene();
     
    }
    public void hardMode(){
        PlayerPrefs.SetInt("Difficulty",3);
        goGameScene();
    }
    public void goGameScene(){
        SceneManager.LoadScene("Game");
    }
}

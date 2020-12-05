using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUIControler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Button resumebtn;
    [SerializeField] private Button quitbtn;

    [SerializeField] private Text lifetxt;
    [SerializeField] private Text scoretxt;
    [SerializeField] private Text nroWavetxt;
    [SerializeField] private Text scorePausetxt;

    public static bool isPaused  = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        resumebtn.onClick.AddListener(()=>Resume());
        quitbtn.onClick.AddListener(()=>BackToMenu());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateLife();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }
    void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
    void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void UpdateLife(){
        lifetxt.text = "LIFES: "+ Player.instance.lifes.ToString();
    }
    private void UpdateScore(){
        //print(Player.instance.score);
        scorePausetxt.text = "SCORE: "+ Player.instance.score.ToString();
        scoretxt.text = "SCORE: "+ Player.instance.score.ToString();
        PlayerPrefs.SetInt("score",Player.instance.score);
    }
}

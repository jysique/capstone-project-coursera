using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [HideInInspector]public int lifes;
    [HideInInspector]public int score;

    private int multiplicator = 1;
    private bool invisible = false;

    public static Player instance;
    private void Awake() {
        MakeInstance();
    }
    void MakeInstance(){
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        lifes = 3;
        score = 0;
    }
    public void upScore(int points){
        score+=points * multiplicator;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            if (!invisible)
            {
                lifes--;
            }
            Destroy(other.gameObject);
            if(lifes <= 0){
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void DebuffTimerInvicibility(){
        StartCoroutine(DebuffInvicibility());
    }

    IEnumerator DebuffInvicibility(){
        invisible = true;
        yield return new WaitForSeconds(10f);
        invisible = false;
    }
    //DEBUFF
    public void DebuffLife(){
        lifes++;
    }
    public void DebuffDoubleScore(){
        multiplicator *=2;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] private GameObject debuffLife;
    [SerializeField] private GameObject debuffInvi;
    [SerializeField] private GameObject debuffDouble;

    void Start()
    {
        debuffLife  = Resources.Load("life") as GameObject;
        debuffInvi  = Resources.Load("invi") as GameObject;
        debuffDouble  = Resources.Load("double") as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet"){
            Transform sp = gameObject.transform;
            Destroy(gameObject);
            Destroy(other.gameObject);
            Player.instance.upScore(5);
            InstantiateDebuff(sp);
        }   
    }
    void InstantiateDebuff(Transform _sp){
        int r = Random.Range(0,100);
        if(55f < r && r < 60f ){
            CreateBuffLife(_sp);
        }else if(35f < r && r < 40f){
            CreateBuffDobleScore(_sp);
        }else if(95f < r && r < 100f){
            CreateBuffInvicibility(_sp);
        }
    }
    void CreateBuffLife(Transform _newpos){
        Instantiate(debuffLife,_newpos.position,_newpos.rotation);
    }
    void CreateBuffInvicibility(Transform _newpos){
        Instantiate(debuffInvi,_newpos.position,_newpos.rotation);
    }
    void CreateBuffDobleScore(Transform _newpos){
        Instantiate(debuffDouble,_newpos.position,_newpos.rotation);
    }

}

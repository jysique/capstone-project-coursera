using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferCollider : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "player"){
            if(gameObject.name.Contains("double")){
                Player.instance.DebuffDoubleScore();
            }else if(gameObject.name.Contains("life")){
                Player.instance.DebuffLife();
            }else if(gameObject.name.Contains("invi")){
                Player.instance.DebuffTimerInvicibility();
            }
            Destroy(gameObject);
        }  
    }
}

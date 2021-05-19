using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;

    private void OnTriggerEnter(Collider other){
        Debug.Log("Bandera");
        if(other.CompareTag("Player")){
            if(lastLevel){
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}

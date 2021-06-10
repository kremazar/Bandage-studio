using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            if (Input.GetKeyDown("e")){
                    SceneManager.LoadScene("bolnickaSoba1");
            }
        }
    }   

}

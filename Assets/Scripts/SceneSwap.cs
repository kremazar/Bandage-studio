using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{

    public AudioSource playSound;

    [SerializeField] public Fade canvas;

    public bool inside = false;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            inside = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            inside = false;
        }
    }

    void Update() {
        if(inside) {
            if (Input.GetKeyDown("e")){
                playSound.Play();
                canvas.FadeMe();
                if(SceneManager.GetActiveScene().name == "bolnickaSoba 1") {
                    SceneManager.LoadScene("bolnica horor");
                }
                if(SceneManager.GetActiveScene().name == "bolnica horor") {
                    SceneManager.LoadScene("bolnickaSoba 1");
                }
            }
        }
    }

}

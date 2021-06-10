using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    [SerializeField]public GameObject ClipboardHands;
    [SerializeField]public GameObject ClipboardWorld;

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
                ClipboardHands.SetActive(true);
                ClipboardWorld.SetActive(false);
            }
        }
    }

}

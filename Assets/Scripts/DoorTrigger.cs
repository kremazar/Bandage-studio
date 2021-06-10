using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]private Animator myDoor = null;
    private bool openTrigger = false;

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
        if (Input.GetKeyDown("e")){
            if(inside) {
                if(!openTrigger) {
                    myDoor.Play("Door_Open", 0, 0.0f);
                    openTrigger = true;
                }
                else if(openTrigger) {
                    myDoor.Play("Door_Close", 0, 0.0f);
                    openTrigger = false;
                }
            }
        }
    }
}
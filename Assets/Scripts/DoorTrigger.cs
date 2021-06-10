using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]private Animator myDoor = null;

    private bool interacting = false;
    private bool openTrigger = false;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            if (Input.GetKeyDown("e")){
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
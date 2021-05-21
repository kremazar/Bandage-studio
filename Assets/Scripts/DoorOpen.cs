using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator animator;

    public GameObject OpenPanel = null;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            doorOpen = true;
            //Doors("Open");
            OpenPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if(doorOpen){
            doorOpen = false;
            OpenPanel.SetActive(false);
            Doors("Close");
        }
    }

    void Doors(string direction){
        animator.SetTrigger(direction);
    }
    
    void Update(){
        if(doorOpen){
            if(Input.GetKeyDown(KeyCode.E)){
                Doors("Open");
                OpenPanel.SetActive(false);
            }
        }
    }
}

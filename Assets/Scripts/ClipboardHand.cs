using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardHand : MonoBehaviour
{
    [SerializeField]public GameObject ClipboardHands;
    [SerializeField]public GameObject ClipboardWorld;
    void Update() {
        if(Input.GetKeyDown("e")){
            ClipboardWorld.SetActive(true);
            ClipboardHands.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperiRuke : MonoBehaviour
{
    public GameObject OperiPanel = null;
    private bool operiRuke;
    public GameObject oruzje = null;
    void Start()
    {
        operiRuke = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            operiRuke = true;
            OperiPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (operiRuke)
        {
            operiRuke = false;
            OperiPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (operiRuke)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OperiPanel.SetActive(false);
                oruzje.SetActive(true);
            }
        }
    }
}

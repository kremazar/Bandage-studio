using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    [SerializeField]public GameObject hpBar;
    [SerializeField]public GameObject ammo;
    [SerializeField]public GameObject weapons;
    public void FadeMe() {
        StartCoroutine (DoFade());
    }

    IEnumerator DoFade() {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        ammo.SetActive(false);
        hpBar.SetActive(false);
        weapons.SetActive(false);
        while (canvasGroup.alpha<1) {
            canvasGroup.alpha += Time.deltaTime / 3;
            yield return null;
        }
        canvasGroup.interactable = false;
        
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{
    public AudioSource cointFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Hello");
            cointFX.Play();
            CointText.cointCount += 1;
            this.gameObject.SetActive(false);
        }
    }
}

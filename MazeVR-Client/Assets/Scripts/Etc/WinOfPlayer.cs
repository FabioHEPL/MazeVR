using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class WinOfPlayer : MonoBehaviour
{
    [SerializeField] GameObject winOfPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            winOfPlayer.SetActive(true);
        }
    }
}

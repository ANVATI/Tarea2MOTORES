using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private AudioSource mushroom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mushroom.Play();
        }
    }
}

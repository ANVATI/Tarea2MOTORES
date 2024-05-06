using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Coffe : MonoBehaviour
{
    [SerializeField] private AudioSource coffe;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            coffe.Play();
        }
    }

}

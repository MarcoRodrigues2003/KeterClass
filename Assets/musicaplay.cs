using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaplay : MonoBehaviour
{

    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc.Play();
    }
}

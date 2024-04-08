using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsound : MonoBehaviour
{

    public AudioSource tickSource;

    private void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            tickSource.Play();
        }
    }

}

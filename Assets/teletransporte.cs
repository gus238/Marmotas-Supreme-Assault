using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletransporte : MonoBehaviour
{
    public Transform warp;
    public AudioSource sonido;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject objeto = collision.gameObject;
            objeto.transform.position = warp.position;
            sonido.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

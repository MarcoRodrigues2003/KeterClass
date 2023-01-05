using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarril : MonoBehaviour
{
    private Transform player;

    public GameObject bulletEsq;
    public GameObject bulletparentEsq;

    public GameObject bulletDir;
    public GameObject bulletparentDir;

    private bool agrobool = false;

    public float agrorange;
    public float life;

    public float firerate;
    private float nextfiretime;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < agrorange)
        {
            agrobool = true;
        }


        if (agrobool == true)
            if (nextfiretime < Time.time)
            {
                Instantiate(bulletEsq, bulletparentEsq.transform.position, Quaternion.identity);
                Instantiate(bulletDir, bulletparentDir.transform.position, Quaternion.identity);
                nextfiretime = Time.time + firerate;
            }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Código relativo há morte do inimigo
        if (collision.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }

    }
}
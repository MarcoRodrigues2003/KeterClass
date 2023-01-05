using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarril : MonoBehaviour
{
    private Transform player;

    public GameObject bulletEsq;
    public GameObject bulletparentEsq;

    public GameObject bulletDir;
    public GameObject bulletparentDir;

    private bool agrobool = false;
    private bool IsDead = false;

    public float agrorange;
    public float life;

    public float firerate;
    private float nextfiretime;

    public Animator Barril;

    public new Collider2D collider;



    // Atribuição de valores a variáveis
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Barril = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider2D>();
    }

    // código do firerate e distância de ataque
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < agrorange)
        {
            agrobool = true;
        }


        if(agrobool == true)
        if (nextfiretime < Time.time)
        {
            Instantiate(bulletEsq, bulletparentEsq.transform.position, Quaternion.identity);
            Instantiate(bulletDir, bulletparentDir.transform.position, Quaternion.identity);
            nextfiretime = Time.time + firerate;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(IsDead==false)
        {
            //Código relativo há morte do inimigo
            if (collision.CompareTag("Spike"))
            {
                IsDead = true;
                Barril.SetBool("BarrilBoom", true);
                Destroy(gameObject, 2f);
            }
            else if (collision.CompareTag("PlayerBullet"))
            {              
                IsDead = true;
                Barril.SetBool("BarrilBoom", true);
                Destroy(gameObject, 2f);
            }
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_behaviour : MonoBehaviour
{
    public Transform enemy;
    public GameObject bullet;
    public GameObject bulletparent;
    public GameObject DeathAnimation;
   
    private Transform player;
    public Transform bracorotation;
    public Transform braco;
    public Transform BulletP;
    public Transform OlhoMauTrans;


    public float speed;
    public float stoppingdistance;
    public float retreatdistance;
    public float agrorange;
    public float life;
    
    public float firerate;
    private float nextfiretime;


    public Vector2 relativePoint;
    public bool bracorotationMovement;
    public bool BulletPMovement;
    public bool agrobool;

    public SpriteRenderer EnyRender;
    public SpriteRenderer BracoRender;
    public SpriteRenderer OlhoMau;

    public AudioSource Bala;

    // Start is called before the first frame update
    void Start()
    {
        //Vai buscar as informações necessárias no inicio do jogo
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bracorotationMovement = false;
        agrobool = false;
    }

    // Update is called once per frame
    void Update()
    {
        //esta parte diz se o player está dentro do agrorange (distancia até ficar ativo) e se estiver ativa o inimigo
        if (Vector2.Distance(transform.position,player.position)<agrorange)
        {
            agrobool = true;
        }

        //Código relativo ao movimento do inimigo e para que lado este se vai virar
        if (agrobool == true)
        {
             OlhoMau.enabled = true;

            //Chase Player
            if (Vector2.Distance(transform.position, player.position) > stoppingdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingdistance && Vector2.Distance(transform.position, player.position) > retreatdistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            // fire function
            if (nextfiretime < Time.time)
            {
                Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
                nextfiretime = Time.time + firerate;
                Bala.Play();
            }


            //Turn to player
            relativePoint = transform.InverseTransformPoint(player.position);

            if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                EnyRender.flipX = true;
                BracoRender.flipY = true;
                OlhoMau.flipX = true;


                if (bracorotationMovement == false)
                {
                    bracorotation.localPosition = new Vector3(1f, bracorotation.localPosition.y, bracorotation.localPosition.z);
                    bracorotationMovement = true;
                    BulletP.localPosition = new Vector3(BulletP.localPosition.x, -0.79f, BulletP.localPosition.z);
                    OlhoMauTrans.localPosition = new Vector3(-1.085f, OlhoMauTrans.localPosition.y, OlhoMauTrans.localPosition.z);
                }

            }
            if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                EnyRender.flipX = false;
                BracoRender.flipY = false;
                OlhoMau.flipX = false;
                if (bracorotationMovement == true)
                {
                    bracorotation.localPosition = new Vector3(-0.49f, bracorotation.localPosition.y, bracorotation.localPosition.z);
                    bracorotationMovement = false;
                    OlhoMauTrans.localPosition = new Vector3(1.085f, OlhoMauTrans.localPosition.y, OlhoMauTrans.localPosition.z);
                }
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Código relativo há morte do inimigo
        if (collision.CompareTag("Spike"))
        {
            GameObject newDeath = Instantiate(DeathAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(newDeath, 2f);
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            GameObject newDeath = Instantiate(DeathAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(newDeath, 2f);
        }

    }


}
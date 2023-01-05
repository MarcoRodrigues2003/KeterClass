using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform enemy;
    public GameObject bullet;
    public GameObject bulletparent;
    public GameObject BarrilGO;
    public GameObject AbilityHead;

    private Transform player;
    public Transform bracorotation;
    public Transform braco;
    public Transform BulletP;


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

    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        //Vai buscar as informações necessárias no inicio do jogo
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bracorotationMovement = false;
        agrobool = false;
        Animator = GetComponent<Animator>();
        Animator.SetBool("IsIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        //esta parte diz se o player está dentro do agrorange (distancia até ficar ativo) e se estiver ativa o Caustic
        if (Vector2.Distance(transform.position, player.position) < agrorange)
        {
            agrobool = true;
        }

        //Código relativo ao movimento do Caustic e para que lado este se vai virar
        if (agrobool == true)
        {

            //Chase Player
            if (Vector2.Distance(transform.position, player.position) > stoppingdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Animator.SetBool("IsIdle", false);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingdistance && Vector2.Distance(transform.position, player.position) > retreatdistance)
            {
                transform.position = this.transform.position;
                Animator.SetBool("IsIdle", true);
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                Animator.SetBool("IsIdle", false);
            }


            // fire function
            if (nextfiretime < Time.time)
            {
                Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
                Instantiate(BarrilGO, transform.position, Quaternion.identity);
                nextfiretime = Time.time + firerate;
            }


            //Turn to player
            relativePoint = transform.InverseTransformPoint(player.position);

            if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                EnyRender.flipX = true;
                BracoRender.flipX = true;

                if (bracorotationMovement == false)
                {
                    bracorotation.localPosition = new Vector3(-1.59f, bracorotation.localPosition.y, bracorotation.localPosition.z);
                    bracorotationMovement = true;
                    BulletP.localPosition = new Vector3(-3.24f, -0.15f, BulletP.localPosition.z);
                }

            }
            if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                EnyRender.flipX = false;
                BracoRender.flipX = false;
                if (bracorotationMovement == true)
                {
                    bracorotation.localPosition = new Vector3(1.68f, bracorotation.localPosition.y, bracorotation.localPosition.z);
                    bracorotationMovement = false;
                    BulletP.localPosition = new Vector3(3.24f, -0.15f, BulletP.localPosition.z);
                }
            }


        }
    }

    void loselife()
    {
        //Código relativo há perda de vida do Caustic
        life--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Código relativo ao tipo de ataque sofrido
        if (collision.CompareTag("Spike"))
        {
            loselife();
            if (life <= 0)
            {
                Animator.SetBool("IsDead", true);
                Invoke("SpawnHead", 0.7f);
                Destroy(gameObject, 0.7f);              
            }
           
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            loselife();
            if (life <= 0)
            {
                Animator.SetBool("IsDead", true);
                Invoke("SpawnHead", 0.7f);
                Destroy(gameObject, 0.7f);
            }
        }
    }

    private void SpawnHead()
    {
        //Código relativo á criação da cabeça do Caustic
        Instantiate(AbilityHead, transform.position, Quaternion.identity);
    }
}

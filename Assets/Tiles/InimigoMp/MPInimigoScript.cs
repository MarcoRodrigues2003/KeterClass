using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    public Transform enemy;
    public GameObject bullet;
    public GameObject bulletparent;

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
        Animator.SetBool("IsDead", false);
        Animator.SetBool("IsIdle", true);
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //esta parte diz se o player está dentro do agrorange (distancia até ficar ativo) e se estiver ativa o soldado
        if (Vector2.Distance(transform.position, player.position) < agrorange)
        {
            agrobool = true;
        }

        //Código relativo ao movimento do soldado e para que lado este se vai virar
        if (agrobool == true)
        {

            //Perseguir Player
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


            // Função de disparo
            if (nextfiretime < Time.time)
            {
                Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
                nextfiretime = Time.time + firerate;
            }


            //Virar para o player
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
        //Código relativo há perda de vida e morte da entidade
        life--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Tipo de ataque que atingiu e as suas sub funções
        if (collision.CompareTag("Spike"))
        {
            loselife();
            if (life <= 0)
            {
                BracoRender.enabled = false;
                Animator.SetBool("IsDead", true);
                Destroy(gameObject, 0.7f);
            }
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            loselife();
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                BracoRender.enabled = false;
                Animator.SetBool("IsDead", true);
                Destroy(gameObject, 0.7f);
            }
        }
    }

}
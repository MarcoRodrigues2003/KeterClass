using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    public AudioSource Bala;

    // Start is called before the first frame update
    void Start()
    {
        //quando a bala é criada corre este código para descobrir a posição do player e dirigir-se para o lado (eixo do x) deste
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, 0);
        Bala.Play();
        Destroy(this.gameObject, 10f);
    }

}

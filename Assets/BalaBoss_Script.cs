using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBoss_Script : MonoBehaviour
{

    public float speed;
    Rigidbody2D bulletRB;


    // Start is called before the first frame update
    void Start()
    {


        //quando a bala é criada corre este código para descobrir a posição do player e dirigir-se para o lado (eixo do x) deste
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(-1 * speed, 0);
        Destroy(this.gameObject, 3f);

    }

}

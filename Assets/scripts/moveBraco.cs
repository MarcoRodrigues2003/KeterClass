using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBraco : MonoBehaviour
{

    public Transform target;
    public bool agrobool;
    public float agrorange = 11;

    // Start is called before the first frame update
    void Start()
    {
        //Vai buscar as informações necessárias no inicio do jogo
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //esta parte diz se o player está dentro do agrorange (distancia até ficar ativo) e se estiver ativa a função do braço apontar para o player
        if (Vector2.Distance(transform.position, target.position) < agrorange)
        {
            agrobool = true;
        }

        if (agrobool==true)
        {
            Vector3 difference = target.position - transform.position;
            difference.Normalize();
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        }
        
    }
}

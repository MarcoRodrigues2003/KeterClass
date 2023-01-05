using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVAlarm : MonoBehaviour
{
    public SpriteRenderer TVSpriteRenderer;

    void Start()
    {
        //Atribuição do valor da variável
        TVSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Mudança da coloração
        TVSpriteRenderer.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
    }

}

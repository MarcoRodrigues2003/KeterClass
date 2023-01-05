using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(speed, 0f);
        Destroy(this.gameObject, 2f);
    }
}

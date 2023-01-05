using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float life;

    public GameObject gameOverPanel;

    private Rigidbody2D _rigidbody;

    public GameObject Player2Dead;

    public bool BarrilAbility = false;


    public float firerate;
    private float nextTimeFire;


    public SpriteRenderer Espinho;
    public Collider2D EspinhoCollider;

    public AudioSource SomEspinho;

    // Start is called before the first frame update
    private void Start()
    {
        //Vai buscar as informações necessárias no inicio do jogo
        _rigidbody = GetComponent<Rigidbody2D>();
        Espinho.enabled = false;
        EspinhoCollider.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //Código relativo á movimentação do player
        var movement = Input.GetAxis("Horizontal2");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump2") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire3") && nextTimeFire < Time.time)
        {
            nextTimeFire = Time.time + firerate;
            Espinho.enabled = true;
            EspinhoCollider.enabled = true;
            Invoke("Disable", 0.2f);
            SomEspinho.Play();
        }


    }

    void Disable()
    {
        //Desabilitará a imagem e colisão do espinho após o ataque estar concluido
        Espinho.enabled = false;
        EspinhoCollider.enabled = false;
    }



    void loselife()
    {
        //Código relativo há perda de vida e morte do jogador
        life--;

        if (life <= 0)
        {
            Gameover();
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Código relativo há deteção do tipo de ataque que colidiu com o player e as respetivas sub funções
        if (collision.CompareTag("bullet"))
        {
            loselife();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("energyBullet"))
        {
            Gameover();
            Destroy(collision.gameObject);
        }
    }


    void Gameover()
    {
        //Código relativo ao que acontece após a morte do player
        CancelInvoke();

        gameOverPanel.SetActive(true);

        GameObject newDeath = Instantiate(Player2Dead, transform.position, transform.rotation);

        Destroy(newDeath, 2f);

        Destroy(gameObject);

        Invoke("StopTime", 3);
    }

    public void StopTime()
    {
        //Código para parar o temppo de jogo depois que o player morreu para não consumir recursos desnecessários
        Time.timeScale = 0f;
    }

}

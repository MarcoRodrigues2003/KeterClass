using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float life;

    public GameObject gameOverPanel;

    private Rigidbody2D _rigidbody;

    public GameObject PlayerDead;

    public bool BarrilAbility = false;

    public AudioSource GameOver;

    public bool Isdead = false;

    // Start is called before the first frame update
    private void Start()
    {
        //Vai buscar as informações necessárias no inicio do jogo
        _rigidbody = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            BarrilAbility = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Código relativo á movimentação do player
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }


    }



    void loselife()
    {
        //Código relativo há perda de vida e morte do jogador
        life--;

        if(life <= 0)
        {
            Gameover();
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Código relativo há deteção do tipo de ataque que colidiu com o player e as respetivas sub funções
       if(collision.CompareTag("bullet"))
       {
            loselife();
            Destroy(collision.gameObject);
       }
       else if(collision.CompareTag("energyBullet"))
       {
            Gameover();
            Destroy(collision.gameObject);
       }
       else if(collision.CompareTag("CausticHead"))
       {
            BarrilAbility = true;
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Level4");
        }
    }


    void Gameover()
    {
        //Código relativo ao que acontece após a morte do player
        Isdead = true;

        CancelInvoke();

        GameOver.Play();

        gameOverPanel.SetActive(true);

        GameObject newDeath = Instantiate(PlayerDead, transform.position, transform.rotation);

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
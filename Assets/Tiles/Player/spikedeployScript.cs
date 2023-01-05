using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikedeployScript : MonoBehaviour
{
    public int rotationOffset = 90;

    public GameObject Spike;
    public GameObject PlayerBarril;
    public SpriteRenderer SpikeRenderer;
    public Collider2D SpikeCollider;
    public float firerate;
    private float nextTimeFire;
    public float AbilityCDR;
    private float abilityTimeFire;

    public PlayerMovement AbilityBarril;

    public AudioSource Espinho;

    // Start is called before the first frame update
    void Start()
    {
        //Irá desabilitar a imagem e a colisão do espinho
        SpikeRenderer.enabled = false;
        SpikeCollider.enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {
        //Código relativo á direção do espinho ser a mesma que a posição do ponteiro no mundo do jogo
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + rotationOffset);

        //Código relativo há ativação do ataque (espinho)
        if(Input.GetButton("Fire1") && nextTimeFire < Time.time)
        {
            nextTimeFire = Time.time + firerate;
            SpikeRenderer.enabled = true;
            SpikeCollider.enabled = true;
            Invoke("Disable", 0.2f);
            Espinho.Play();
        }
        if(Input.GetButton("Fire2") && abilityTimeFire < Time.time && AbilityBarril.BarrilAbility == true)
        {
            abilityTimeFire = Time.time + AbilityCDR;
            Instantiate(PlayerBarril, transform.position, Quaternion.identity);
        }
    }

    void Disable()
    {
        //Desabilitará a imagem e colisão do espinho após o ataque estar concluido
        SpikeCollider.enabled = false;
        SpikeRenderer.enabled = false;
    }
}

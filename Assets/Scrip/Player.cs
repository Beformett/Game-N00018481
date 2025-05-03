using UnityEngine;
using System.Collections;
using Unity.Mathematics;
public class Player : MonoBehaviour
{
    public GameObject FireBallPrefab;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    int numero_Saltos;
    int fuerza_Salto = 5;
    private bool isHurting = false;
    private bool isAttack = false;
    public float fireballSpeed = 7f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetupCaminar();
        SetupSaltar();
        SetupAtacar();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            Debug.Log("Estoy en el piso");
            anim.SetBool("Jump", false);
            numero_Saltos = 0;
        }
        if (collision.gameObject.CompareTag("Enemi") && !isHurting)
        {
            Debug.Log("Estoy chocando");
            StartCoroutine(DisableHurt());
        }
    }
    private IEnumerator DisableHurt()
    {
        isHurting = true;
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Hurt", false);
        isHurting = false;
    }
    void SetupCaminar()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walk", true);
            rb.linearVelocityX = 5;
            sr.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Walk", false);
            rb.linearVelocityX = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Walk", true);
            sr.flipX = true;
            rb.linearVelocityX = -5;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Walk", false);
            rb.linearVelocityX = 0;
        }
    }
    void SetupSaltar()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && numero_Saltos < 2)
        {
            anim.SetBool("Jump", true);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, fuerza_Salto);
            numero_Saltos++;
        }
    }
    void SetupAtacar()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(DisableAttack());
        }
    }
    private IEnumerator DisableAttack()
    {
        isAttack = true;
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.9f);
        Instantiate(FireBallPrefab, transform.position, quaternion.identity);
        anim.SetBool("Attack", false);
        isAttack = false;
    }

}

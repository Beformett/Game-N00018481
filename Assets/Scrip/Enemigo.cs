using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    private Player player;
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        player = FindFirstObjectByType<Player>();
    }

    public void Comportamientos()
    {
        ani.SetBool("attack", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                ani.SetBool("walk", false);
                break;

            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;

            case 2:

                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;

                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                }
                ani.SetBool("walk", true);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ataque"))
        {
            Debug.Log("muerto");
            Destroy(gameObject);
            player.SumarEnemigo();
        }
    }


    void Update()
    {
        Comportamientos();
    }
}


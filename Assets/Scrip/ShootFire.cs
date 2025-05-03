using UnityEngine;

// public class ShootFire : MonoBehaviour
// {
//     Rigidbody2D rb;
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         Destroy(this.gameObject, 5f);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         rb.linearVelocityX = 10f;
//     }
// }
public class ShootFire : MonoBehaviour
{
    public GameObject FireBallPrefab; // Asigna aquí tu prefab de la bola de fuego
    public Transform firePoint;     // El punto desde donde se dispara (puede ser un empty GameObject)

    public void FireBullet() // Este método debe coincidir con el Animation Event
    {
        Instantiate(FireBallPrefab, firePoint.position, firePoint.rotation);
        Destroy(this.gameObject, 5f);
    }
}
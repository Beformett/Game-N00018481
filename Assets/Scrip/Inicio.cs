using UnityEngine;
using UnityEngine.SceneManagement; // Para gestionar escenas

public class CambiarEscena : MonoBehaviour
{
    // Este método se llama al hacer clic en el botón
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}

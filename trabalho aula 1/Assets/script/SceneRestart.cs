using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    public void RestartScene()
    {
        // Pode ser usado o nome da cena atual ou o seu �ndice.
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0); // Isso reiniciar� a primeira cena do build.
    }
}

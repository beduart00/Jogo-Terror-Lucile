using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Método para carregar a cena
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
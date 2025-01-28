using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    [SerializeField] private AudioManager AudioManager;

    public void B_Jugar()
    {
        SceneManager.LoadScene("Mainlevel");
    }

    public void B_Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}

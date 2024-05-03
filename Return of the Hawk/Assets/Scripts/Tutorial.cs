using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    // Nome da cena do menu principal
    public string MainMenu;

    // Método para voltar para o menu principal
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
        Debug.Log("Tutorial Back Button Pressed");
    }
}

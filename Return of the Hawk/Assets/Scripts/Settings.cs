using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
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


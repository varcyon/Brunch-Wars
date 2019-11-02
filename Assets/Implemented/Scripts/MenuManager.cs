using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToBrawl()
    {
        SceneManager.LoadScene("Brunch Brawl Lobby");
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("Prolog");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Main");
    }

    public void ButtonAbout()
    {
        Application.OpenURL("https://github.com/Montece/SurvivalExample");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}

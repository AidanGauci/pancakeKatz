using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScreenManager_Aidan : MonoBehaviour {

	public void PlayAgain()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("MainGameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

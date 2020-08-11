using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    //Hangi sahnede olduğumuz bulup ona bir ekleyip sırayla geçicez.

    public void SceneLoader()
    {
        //Gettinng Scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void StartScene()
    {
        //Başlangıçta skoru sıfırlama
        FindObjectOfType<GameSession>().DestroyOnStart();
        SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Application.Quit();
    }



}

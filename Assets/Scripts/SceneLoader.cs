using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public IntSO money;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneBasedOnMoney()
    {
        if (money.value >= 0)
        {
            LoadScene("Preparation Phase");
        }
        else 
        {
            LoadScene("GameOver");
        }
    }
}

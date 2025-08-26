using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public IntSO money;
    public IntSO days;
    public BoolSO knife;
    public void LoadScene(string sceneName)
    {
        if (knife != null)
        knife.value = false;
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

    public void LoadSceneBasedOnDays()
    {
        if (days.value == 3)
        {
            LoadScene("Win");
        }
        else
        {
            LoadSceneBasedOnMoney();
        }
    }
}

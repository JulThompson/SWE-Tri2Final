using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Assign this in the Inspector

    public void SwitchScene()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(sceneToLoad);
    }
}

using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int id)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(id);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEditor.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int id)
    {
        EditorSceneManager.LoadScene(id);
    }
}

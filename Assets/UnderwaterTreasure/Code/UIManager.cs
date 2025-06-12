using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image[] gems;
    [SerializeField] Animator endGame;
    [SerializeField] SceneChanger change;
    int gemsActivated = 0;
    bool gameEnded;
    
    public void ActivateGem(int id)
    {
        gems[id].color = Color.white;
        gemsActivated++;
        if (gemsActivated == 5)
        {
            endGame.Play("Down");
        }
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        change.ChangeScene(2);
    }

    public bool GetGameEnded
    {
        get { return gameEnded; }
    }
}

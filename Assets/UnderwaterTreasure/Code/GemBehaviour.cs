using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    [SerializeField] UIManager manager;
    [SerializeField] int id;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ActivateGem(id);
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class Camo : MonoBehaviour
{
    [SerializeField] PlayerBehaviour player;
    [SerializeField] GameObject gem;

    Vector3 originalPos;
    Vector3 downPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = gem.transform.position;
        downPos = new Vector3 (originalPos.x, originalPos.y - 5.0f, originalPos.z);
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("el player entro en mi");
            if (!player.GetIsInvisible)
            {
                gem.transform.position = downPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gem.transform.position = originalPos;
        }
    }
}

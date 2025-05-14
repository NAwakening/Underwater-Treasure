using UnityEngine;

public class Camo : MonoBehaviour
{
    [SerializeField] PlayerBehaviour player;
    [SerializeField] GameObject gem;

    Vector3 originalPos;
    Vector3 downPos;
    Vector3 direction = Vector3.up;
    Vector3 initialpos;
    float speed = 3;
    float lerpCronometer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = gem.transform.position;
        downPos = new Vector3 (originalPos.x, originalPos.y - 5.0f, originalPos.z);
        initialpos = downPos;
    }

    void FixedUpdate()
    {
        lerpCronometer += Time.fixedDeltaTime;
        gem.transform.position = Vector3.Lerp(initialpos,);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!player.GetIsInvisible)
            {
                lerpCronometer = 0;
                direction = Vector3.down;
                initialpos = originalPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lerpCronometer = 0;
            direction = Vector3.up;
            initialpos = downPos;
        }
    }
}

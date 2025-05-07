using UnityEngine;

public class DisolveRock : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            anim.Play("Disolve");
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

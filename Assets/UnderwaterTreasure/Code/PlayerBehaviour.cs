using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;

    [SerializeField] Rigidbody rb;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform _camera;
    [SerializeField] Transform orientation;
    [SerializeField] Animator anim;
    [SerializeField] SkinnedMeshRenderer playerRenderer;
    [SerializeField] Material[] materials;
    [SerializeField] GameObject[] bullets;
    [SerializeField] Transform bulletpos;
    [SerializeField] float bulletSpeed;
    [SerializeField] float jumpPower;

    Vector3 direction;
    Vector2 input;
    bool isMoving;
    bool isInHologram;
    bool isInvisible;
    bool canJump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            orientation.forward = (transform.position - new Vector3(_camera.position.x, transform.position.y, _camera.position.z)).normalized;
            direction = (input.x * orientation.right + input.y * orientation.forward);
            playerTransform.forward = Vector3.Slerp(playerTransform.forward, direction.normalized, rotSpeed * Time.fixedDeltaTime);
            if (new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).magnitude > speed)
            {
                Vector3 limitedVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).normalized * speed;
                rb.linearVelocity = new Vector3 (limitedVel.x, rb.linearVelocity.y, limitedVel.z);
            }
        }
        else
        {
            direction = Vector3.zero;
        }
        rb.AddForce(direction.normalized * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            input = value.ReadValue<Vector2>();
            isMoving = true;
            anim.SetBool("isWalking", true);
        }
        else if (value.canceled)
        {
            direction = new Vector3 (0, rb.linearVelocity.y, 0);
            isMoving = false;
            anim.SetBool("isWalking", false);
        }
        
    }

    public void OnHologram(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Material[] newMaterials = playerRenderer.materials;
            if (!isInHologram)
            {
                newMaterials[0] = materials[1];
                isInHologram = true;
                isInvisible = false;
                gameObject.layer = 8;
            }
            else
            {
                newMaterials[0] = materials[0];
                isInHologram = false;
                gameObject.layer = 0;
            }
            playerRenderer.materials = newMaterials;
        }
    }

    public void OnInvisible(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Material[] newMaterials = playerRenderer.materials;
            if (!isInvisible)
            {
                newMaterials[0] = materials[2];
                isInHologram = false;
                isInvisible = true;
                gameObject.layer = 0;
            }
            else
            {
                newMaterials[0] = materials[0];
                isInvisible = false;
            }
            playerRenderer.materials = newMaterials;
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            if (canJump)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                canJump = false;
            }
            
        }
    }

    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (!bullets[i].activeSelf)
                {
                    bullets[i].SetActive(true);
                    bullets[i].transform.position = bulletpos.position;
                    bullets[i].GetComponent<Rigidbody>().AddForce(playerTransform.forward * bulletSpeed, ForceMode.Force);
                    break;
                }
            }
        }
    }

    public bool GetIsInvisible
    {
        get { return isInvisible; }
    }
}

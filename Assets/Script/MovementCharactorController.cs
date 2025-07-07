using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharactorController : MonoBehaviour
{
    [SerializeField]
    private UIInventory uiInventory;
    [SerializeField]
    private PlayerStamina playerStamina;
    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float runSpeed = 5.0f;
    [SerializeField]
    private float moveSpeed=5.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpForce = 3.0f;
    [SerializeField]
    private Transform mainCamera;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController characterController;
    private Animator animator;

    public float MoveSpeed => moveSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Movement();

        GravityAndJump();

        Attack();
        
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, mainCamera.eulerAngles.y, 0);
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxisRaw("Sprint"));

        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        if (playerStamina.IsEmergencyMode == true)
        {
            moveSpeed = walkSpeed;
            offset = 0.5f;
        }
        animator.SetFloat("horizontal", x * offset);
        animator.SetFloat("vertical", z * offset);


        Vector3 dir = mainCamera.rotation * new Vector3(x, 0, z);
        moveDirection = new Vector3(dir.x, moveDirection.y, dir.z);
    }

    private void GravityAndJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)
        {
            animator.SetTrigger("onJump");
            moveDirection.y = jumpForce;
        }
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

    }

    private void Attack()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("onAttack");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Eatable"))
        {
            int index = hit.gameObject.GetComponent<EatableObject>().ItemIndex;
            uiInventory.GetItem(index);
            Destroy(hit.gameObject);

            Debug.Log(hit.gameObject.name);
        }
    }
}

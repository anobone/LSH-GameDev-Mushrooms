using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;


[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator playerAnimator;

    private BoxCollider2D hitBox;
    [SerializeField] private GameObject shieldObject;

    private bool isPermitted = true;
    private bool disabledInput = false;
    private float direction;
    private Vector2 animDirection;
    private bool isWalking = false;
    private bool isParrying = false;

    [SerializeField] private float moveSpeed;
    [Header("Parry time and cooldown time")]
    [SerializeField] float parryTime; [SerializeField] float cooldownTime;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        shieldObject.SetActive(false);
    }

    private void Update()
    {
        if (!disabledInput)
        {
            rigidbody2D.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.Translate(rigidbody2D.velocity * Time.deltaTime);
                direction = GetDirection(Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg);
                isWalking = true;
                HandleDirection();
            }
            ChangeAnimation();
            isWalking = false;
        }
    }

    public void ButtonForParry()
    {
        if (isPermitted)
        {
            StartCoroutine(Parry());
        }
    }
    public IEnumerator Parry()
    {
        isPermitted = false;
        shieldObject.transform.rotation = Quaternion.Euler
            (0, 0, -direction);
        isParrying = true;
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(parryTime);
        shieldObject.SetActive(false);
        isParrying = false;
        isPermitted = true;
        yield return new WaitForSeconds(cooldownTime);
    }

    public void DisableInput()
    {
        disabledInput = !disabledInput;
    }

    public float GetDirection(float angle)
    {
        return Mathf.Round(angle/90f) * 90;
    }

    public void HandleDirection()
    {
        animDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
        animDirection.Normalize();
    }

    public void ChangeAnimation()
    {
        if (animDirection != Vector2.zero)
        {
            playerAnimator.SetFloat("Horizontal", animDirection.x);
            playerAnimator.SetFloat("Vertical", animDirection.y);
        }

        if (isParrying)
        {
            playerAnimator.SetFloat("handleStats", 1f);
        }
        else 
        {
            if (isWalking)
            {
                playerAnimator.SetFloat("handleStats", 0.5f);
            }
            else
            {
                playerAnimator.SetFloat("handleStats", 0f);
            }
        }
    }
}

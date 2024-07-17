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

    public bool isPermitted = true;
    public bool disabledInput = false;
    public float direction;

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
            }

            ChangeAnimation(direction);
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
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(parryTime);
        shieldObject.SetActive(false);
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

    public void ChangeAnimation(float angle)
    {
        playerAnimator.SetFloat("direction", angle);
        /*switch (angle)
        {
            case 0f:
                playerAnimator.Play("WalkingForward");
                
                break;
            case 90f:
                playerAnimator.Play("WalkingRight");
                break;
            case -90f:
                playerAnimator.Play("Left");
                break;
            case 180f: case -180f:
                playerAnimator.Play("back");
                break;
            default:
                break;
        }*/
    }
}

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
    //[SerializeField] private Animator animator;

    private BoxCollider2D hitBox;
    [SerializeField] private GameObject shieldObject;

    public bool isPermitted = true;
    public bool disabledInput = false;

    [SerializeField] private float moveSpeed;
    void Start()
    {
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
                //animator.SetBool("Running", true);
                transform.Translate(rigidbody2D.velocity * Time.deltaTime);
            }
            else
            {
                //animator.SetBool("Running", false);
            }
            SetDirection(Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg);
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
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        shieldObject.SetActive(false);
        isPermitted = true;
        yield return new WaitForSeconds(1f);
    }

    public void DisableInput()
    {
        disabledInput = !disabledInput;
    }

    public void SetDirection(float angle)
    {
        if (angle < -45 && angle > -135) { sprite.flipX = true; }
        else { sprite.flipX = false; }
    }
}

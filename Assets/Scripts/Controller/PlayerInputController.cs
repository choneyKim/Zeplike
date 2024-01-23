using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private GameObject talkPop;
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos-(Vector2)transform.position).normalized;
        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);
        }
    }
    private void FixedUpdate()
    {
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "talk")
        {
            talkPop.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "talk")
        {
            talkPop.SetActive(false);
        }
    }
}

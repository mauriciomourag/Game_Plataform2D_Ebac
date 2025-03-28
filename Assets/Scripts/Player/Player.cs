using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Speed Setup")]
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }

        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {            
            myRigidbody.linearVelocity = new Vector2(-_currentSpeed, myRigidbody.linearVelocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {            
            myRigidbody.linearVelocity = new Vector2(_currentSpeed, myRigidbody.linearVelocity.y);
        }

        if(myRigidbody.linearVelocity.x > 0)
        {
            myRigidbody.linearVelocity -= friction;
        }

        else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}


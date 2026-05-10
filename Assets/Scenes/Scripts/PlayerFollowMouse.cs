using UnityEngine;

public class PlayerFollowMouse : MonoBehaviour
{
    public float speed = 5f;
    public bool canMove = true;

    private Animator animator;
    private bool hasStartedMoving;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    void OnEnable()
    {
        CursorInputRouter.Instance.Held += HandleCursorHeld;
    }

    void OnDisable()
    {
        if (!CursorInputRouter.HasInstance)
        {
            return;
        }

        CursorInputRouter.Instance.Held -= HandleCursorHeld;
    }

    void HandleCursorHeld(Vector3 worldPosition)
    {
        if (!canMove || !StartIntroAnimator.GameStarted || ScoreManager.CurrentPhase != ScoreManager.GamePhase.Painting)
        {
            return;
        }

        if (!hasStartedMoving)
        {
            hasStartedMoving = true;

            if (animator != null)
            {
                animator.enabled = true;
            }
        }

        worldPosition.z = 0f;
        transform.position = Vector2.Lerp(transform.position, worldPosition, speed * Time.deltaTime);
    }
}

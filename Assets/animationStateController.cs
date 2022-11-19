using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");

        if (!isRunning && forwardPressed || backwardPressed || leftPressed || rightPressed)
        {
            animator.SetBool("isRunning", true);
        }

        if (isRunning && !forwardPressed && !backwardPressed && !leftPressed && !rightPressed)
        {
            animator.SetBool("isRunning", false);
        }

    }

}

using UnityEngine;

public class GrabBall : MonoBehaviour
{
    // The ball object
    public GameObject ball;

    // The player's grab distance
    public float grabDistance = 1.0f;

    //get ball rigidbody
    private Rigidbody ballRB;

    // The player's throwing point
    public Transform throwPoint;

    // Is the player holding the ball?
    public bool holdingBall = false;


    private void Awake()
    {
        ballRB = ball.GetComponent<Rigidbody>();
    }
    public void AttachBall()
    {
        if (!holdingBall && ballRB.velocity.magnitude <= 0 && Vector3.Distance(ball.transform.position, transform.position) <= grabDistance)
        {
            // Set holdingBall to true
            holdingBall = true;

            Debug.Log("Attach");
            // Set the ball's position and rotation to match the player's throwing point
            ball.transform.position = throwPoint.position;
            ball.transform.rotation = throwPoint.rotation;

            // Make the ball a child of the player object
            ball.transform.parent = transform;
        }
    }

    public void ReleaseBall()
    {
        // Release the ball
        ball.transform.parent = null;
    }
}

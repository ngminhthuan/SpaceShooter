using UnityEngine;

public class ShipMovementCtrl : MonoBehaviour
{
    const float Position_y = -3.5f;
    public float moveSpeed = 1f; // Speed of the ship's movement
    private Vector3 touchStartPosition;

    private void Start()
    {
        PlayerController.Instance.transform.position = new Vector3(0, Position_y, 0);
    }
    void Update()
    {
#if UNITY_ANDROID
        if (Input.GetMouseButtonDown(0))
        {
            // Record the starting position of the drag
            touchStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            // Calculate the drag distance
            Vector3 touchCurrentPosition = Input.mousePosition;
            float deltaX = touchCurrentPosition.x - touchStartPosition.x;

            PlayerController.Instance.MovePlayer(deltaX, moveSpeed);

            // Update the starting position for the next frame
            touchStartPosition = touchCurrentPosition;
        }
#elif UN
#endif

    }

    public void ShipStartPosition()
    {
        PlayerController.Instance.transform.position = new Vector3(0, Position_y, 0);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Only follow Y position (vertical movement)
        Vector3 desiredPosition = new Vector3(
            transform.position.x,           // Keep current X
            player.position.y + offset.y,   // Follow player's Y with offset
            transform.position.z + offset.z // Keep Z offset (depth)
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player1, Player2;
    [SerializeField] Vector2 minBorder; // bottom-left
    [SerializeField] Vector2 maxBorder; // top-right
    [SerializeField] float zoomMultiplier = 0.5f;
    [SerializeField] float minZoomValue = 5f;
    [SerializeField] float zoomSmoothTime = 0.5f;

    private float _targetZoom;
    private float _zoomVelocity;

    void LateUpdate()
    {
        // --- Center between players ---
        Vector2 midpoint = (Player1.position + Player2.position) / 2;
        Vector3 desiredPos = new Vector3(midpoint.x, midpoint.y, -10);

        // --- Clamp to borders ---
        float clampedX = Mathf.Clamp(desiredPos.x, minBorder.x, maxBorder.x);
        float clampedY = Mathf.Clamp(desiredPos.y, minBorder.y, maxBorder.y);

        transform.position = new Vector3(clampedX, clampedY, -10);

        // --- Zoom based on distance ---
        float distance = Vector2.Distance(Player1.position, Player2.position);
        _targetZoom = Mathf.Max(minZoomValue, distance * zoomMultiplier);

        Camera.main.orthographicSize = Mathf.SmoothDamp(
            Camera.main.orthographicSize,
            _targetZoom,
            ref _zoomVelocity,
            zoomSmoothTime
        );
    }
}

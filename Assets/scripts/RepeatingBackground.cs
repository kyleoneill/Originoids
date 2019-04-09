using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Renderer background;
    public Transform backgroundTopLeft;
    public Transform backgroundTopRight;
    public Transform backgroundBottomLeft;
    public Transform backgroundBottomRight;

    private Camera _camera;
    private float backgroundWidth;
    private float backgroundHeight;
    // Start is called before the first frame update
    void Awake()
    {
        _camera = GetComponent<Camera>();
        backgroundWidth = background.bounds.size.x;
        backgroundHeight = background.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float xCenter = Mathf.Round(_camera.transform.position.x / backgroundWidth) * backgroundWidth;
        float yCenter = Mathf.Round(_camera.transform.position.y / backgroundHeight) * backgroundHeight;
        Vector2 center = new Vector2(xCenter, yCenter);

        backgroundTopLeft.position = new Vector2(center.x - backgroundWidth / 2, center.y + backgroundHeight / 2);
        backgroundTopRight.position = new Vector2(center.x + backgroundWidth / 2, center.y + backgroundHeight / 2);
        backgroundBottomLeft.position = new Vector2(center.x - backgroundWidth / 2, center.y - backgroundHeight / 2);
        backgroundBottomRight.position = new Vector2(center.x + backgroundWidth / 2, center.y - backgroundHeight / 2);
    }
}

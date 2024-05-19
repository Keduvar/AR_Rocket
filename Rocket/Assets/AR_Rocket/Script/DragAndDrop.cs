using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
        rb.useGravity = false;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;
    }
}
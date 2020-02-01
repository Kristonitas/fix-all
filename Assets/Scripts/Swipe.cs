using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float swipeRadius = 10;

    private float rotation = 0;
    private float verticalOffset = 0;
    private bool anchorTop = true;
    private Vector2 start;
    private Transform content;

    void Awake()
    {
        content = transform.GetChild(0);
        content.localPosition = new Vector3(0, this.swipeRadius * this.AnchorMultiplier(), 0);
    }

    float AnchorMultiplier()
    {
        return this.anchorTop ? 1 : -1;
    }

    void Update()
    {
        this.HandleInput();

        transform.localPosition = new Vector3(0, (this.verticalOffset - this.swipeRadius) * this.AnchorMultiplier(), 0);
        transform.localRotation = Quaternion.Euler(0, 0, this.rotation * Mathf.Rad2Deg);
    }

    void HandleInput()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var localPos = transform.parent.InverseTransformPoint(worldPos);

        if (Input.GetMouseButtonDown(0))
        {
            // TODO: somehow include existing vertical offset
            start = localPos;
            if (start.y < 0)
            {
                this.anchorTop = false;
            }
            else
            {
                this.anchorTop = true;
            }

            content.localPosition = new Vector3(0, this.swipeRadius * this.AnchorMultiplier(), 0);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 diff = (Vector2)localPos - start;
            this.verticalOffset = Mathf.Sqrt(Mathf.Pow(this.swipeRadius, 2) - Mathf.Pow(diff.x, 2)) - this.swipeRadius + diff.y * this.AnchorMultiplier();
            this.rotation = Mathf.Asin(diff.x / this.swipeRadius);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Release
        }
        else
        {
            // After release
        }
    }
}

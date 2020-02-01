using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float swipeRadius = 10;

    private float rotation = 0;
    private float verticalOffset = 0;
    private bool anchorTop = true;
    private Vector2 start;
    private Transform content;
    private bool goOut = false;

    void Awake()
    {
        content = transform.GetChild(0);
        content.localPosition = new Vector3(0, this.swipeRadius * this.AnchorMultiplier, 0);
    }

    float AnchorMultiplier
    {
        get
        {
            return this.anchorTop ? 1 : -1;
        }
    }

    void Update()
    {
        this.HandleInput();

        transform.localPosition = new Vector3(this.start.x, (this.verticalOffset - this.swipeRadius) * this.AnchorMultiplier + this.start.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, -this.rotation * this.AnchorMultiplier);
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

            content.localPosition = new Vector3(-this.start.x, this.swipeRadius * this.AnchorMultiplier - this.start.y, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 diff = (Vector2)localPos - start;
            float lowering = Mathf.Sqrt(Mathf.Pow(this.swipeRadius, 2) - Mathf.Pow(diff.x, 2)) - this.swipeRadius;
            this.verticalOffset = -lowering + diff.y * this.AnchorMultiplier;
            this.rotation = Mathf.Asin(diff.x / this.swipeRadius) * Mathf.Rad2Deg;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Abs(this.rotation) > 10)
            {
                this.goOut = true;
            }
        }
        else
        {
            if (this.goOut)
            {
                this.rotation = this.rotation * Mathf.Pow(2f, Time.deltaTime * 10);
                if (Mathf.Abs(this.rotation) > 50)
                {
                    GameObject.Destroy(gameObject);
                }
            }
            else
            {
                this.rotation = this.rotation * Mathf.Pow(0.5f, Time.deltaTime * 10);
                this.verticalOffset = this.verticalOffset * Mathf.Pow(0.5f, Time.deltaTime * 10);
            }
        }
    }
}

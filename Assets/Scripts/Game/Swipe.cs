using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float swipeRadius = 10;
    public AudioSource leftAudio;
    public AudioSource rightAudio;

    private float rotation = 0;
    private float verticalOffset = 0;
    private bool anchorTop = true;
    private Vector2 start;
    private Transform content;
    private bool goOut = false;
    private float volume = 0;

    void Awake()
    {
        content = transform.GetChild(0);
        content.localPosition = new Vector3(0, this.swipeRadius * this.AnchorMultiplier, 0);
    }

    float AnchorMultiplier
    {
        get
        {
            return this.anchorTop ? -1 : 1;
        }
    }

    void OnSwipe(bool swipedRight)
    {
        CardData cardData = GetComponent<Card>().cardData;

        if (swipedRight)
        {
            EventCoordinator.TriggerEvent(EventName.Input.Swipe.FinishRight(), GameMessage.Write().WithCardData(cardData));
        }
        else
        {
            EventCoordinator.TriggerEvent(EventName.Input.Swipe.FinishLeft(), GameMessage.Write().WithCardData(cardData));
        }
    }

    void Update()
    {
        if(!GameStateView.HasState(GameState.started) || GameStateView.HasState(GameState.ended))
            return;
        HandleInput();
        UpdateReleased();
        UpdateVolume();

        transform.localPosition = new Vector3(this.start.x, (this.verticalOffset - this.swipeRadius) * this.AnchorMultiplier + this.start.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, -this.rotation * this.AnchorMultiplier);
    }

    void HandleInput()
    {
        if (this.goOut)
        {
            return;
        }

        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var localPos = transform.parent.InverseTransformPoint(worldPos);

        if (Input.GetMouseButtonDown(0))
        {
            // TODO: somehow include existing vertical offset
            start = localPos;
            if (start.y > 0)
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
            float newRotation = Mathf.Asin(diff.x / this.swipeRadius) * Mathf.Rad2Deg;

            this.volume += Mathf.Abs(newRotation - this.rotation) * 2;
            this.volume = Mathf.Min(this.volume, 1);

            this.rotation = newRotation;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Abs(this.rotation) > 2)
            {
                this.goOut = true;
                OnSwipe(this.rotation > 0);
                this.volume = 1;
            }
        }
        else
        {
            if (!this.goOut && Mathf.Abs(this.rotation) < 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    this.goOut = true;
                    this.rotation = 0.1f;
                    OnSwipe(true);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    this.goOut = true;
                    this.rotation = -0.1f;
                    OnSwipe(false);
                }

                if (this.goOut)
                {
                    this.start = new Vector2();
                    content.localPosition = new Vector3(0, this.swipeRadius, 0);
                    this.anchorTop = false;
                    this.volume = 2;
                }
            }
        }
    }

    void UpdateVolume()
    {
        if (this.goOut)
        {
            this.volume = Mathf.MoveTowards(this.volume, 0, Time.deltaTime * 2);
        }
        else
        {
            this.volume = Mathf.MoveTowards(this.volume, 0, Time.deltaTime * 5);
        }

        float clippedVolume = Mathf.Clamp01(this.volume) * Mathf.Clamp01(Mathf.Abs(this.rotation / 5));

        if (this.rotation < 0)
        {
            this.rightAudio.volume = clippedVolume;
            this.leftAudio.volume = 0;
        }
        else
        {
            this.leftAudio.volume = clippedVolume;
            this.rightAudio.volume = 0;
        }
    }

    void UpdateReleased()
    {
        if (this.goOut)
        {
            this.rotation = this.rotation * Mathf.Pow(1.1f, Time.deltaTime * 10);
            this.rotation += 40 * Time.deltaTime * Mathf.Sign(this.rotation);
            if (Mathf.Abs(this.rotation) > 50)
            {
                GameObject.Destroy(gameObject);
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            this.rotation = this.rotation * Mathf.Pow(0.5f, Time.deltaTime * 10);
            this.verticalOffset = this.verticalOffset * Mathf.Pow(0.5f, Time.deltaTime * 10);
        }
    }

}

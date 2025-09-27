using UnityEngine;

public class HueShifter : MonoBehaviour
{
    public float Speed = 1;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Hue cycles between 0 and 1
        float hue = Mathf.PingPong(Time.time * Speed, 1f);

        // Convert HSV -> RGB (full saturation & value)
        Color color = Color.HSVToRGB(hue, 1f, 1f);

        this.GetComponent<SpriteRenderer>().color = color;
    }
}

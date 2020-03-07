using UnityEngine;

public class ZoneAggressionController : MonoBehaviour
{
    private SpriteColor spriteColor;

    private float Range;

    private Transform TransformZone;

    private SpriteRenderer SpriteZone;

    private void Awake()
    {
        TransformZone = transform;
        SpriteZone = GetComponent<SpriteRenderer>();
        Range = UnityEngine.Random.Range(1.7f, 3f);
        spriteColor = new SpriteColor(SpriteZone.color);
        TransformZone.localScale = new Vector3(Range, Range, 1);
    }

    public void SetRange(float value)
    {
        Range = value;
        TransformZone.localScale = new Vector3(Range, Range, 1);
    }

    public void StateAnger()
    {
        SpriteZone.color = spriteColor.GetColorAnger();
    }

    public void StateCalm()
    {
        SpriteZone.color = spriteColor.GetColorCalm();
    }
}
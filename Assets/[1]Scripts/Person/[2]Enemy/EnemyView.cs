using UnityEngine;
using Zenject;
using System;

public class EnemyView : Person
{
    private IMessage iMessage;

    [SerializeField]
    private ScrObjModel scrObjModel;

    private Presenter presenter = new Presenter();
    private Model model = new Model();
    public Move move;
    public ZoneAggressionController zoneAggressionController;

    private Person Target;

    public override event Action<int> OnTakeDamage;

    private int DirectionLook = 1;

    private bool CanMove;

    private Transform TargetPosition;
    private Transform View;

    private Vector2 DirectionMove;
    private Vector2 TargetDirection;
    private Vector2 TargetDirectionNormalized;

    [Inject]
    public void Construct(IMessage message)
    {
        iMessage = message;
    }

    public void SetTarget(Person newTarget)
    {
        Target = newTarget;
        if (Target != null)
        {
            TargetPosition = newTarget.transform;
            zoneAggressionController.StateAnger();
            iMessage.MessageOne("<color=red>Enemy</color>: I see you!!");
        }
        else
        {
            zoneAggressionController.StateCalm();
            iMessage.MessageOne("<color=red>Enemy</color>: Where did you go ..");
        }
    }

    private void Awake()
    {
        View = transform.Find("View");
        presenter.SetSetting(model, this, move, scrObjModel);
    }

    private void Update()
    {
        AIController();
        Move();
    }

    private void AIController()
    {
        if (Target != null) TargetFound();
        else TargetIsLost();
    }

    private void TargetFound()
    {
        TargetDirection = new Vector2(TargetPosition.position.x, TargetPosition.position.y) - new Vector2(transform.position.x, transform.position.y);
        TargetDirectionNormalized = TargetDirection.normalized;
        DirectionMove = TargetDirectionNormalized;
        CanMove = true;
    }

    private void TargetIsLost() { CanMove = false; }

    private void Move()
    {
        if (move != null && CanMove) move.OnMove(transform, DirectionMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HeroView>()) TakeDamage(UnityEngine.Random.Range(1, 7));
    }

    public override void TakeDamage(int takeDamege)
    {
        iMessage.MessageOne("<color=red>Enemy</color>: Ai, it hurts me");
        OnTakeDamage(takeDamege);
        iMessage.MessageOne($"<color=red>Enemy</color>: Takes damage - {takeDamege}");
    }

    public override void HealthAnimation(int curHealth) { return; }

    public override void Death()
    {
        Destroy(gameObject);
        iMessage.MessageOne("<color=red>Enemy</color>: You defeated me, khe");
    }

    public void NewPosition(Vector3 transform)
    {
        gameObject.transform.position = transform;
    }

    public class Factory : PlaceholderFactory<EnemyView> { }
}
using UnityEngine;
using Zenject;
using System;

public class EnemyView : Person
{
    private IMessage iMessage; // TODO: DeleteMe!!

    [SerializeField]
    private ScrObjModel scrObjModel;
    private Presenter presenter = new Presenter();
    private Model model = new Model();

    public Move move;

    public Person Target;

    public override event Action<int> OnTakeDamage;

    private int DirectionLook = 1;
    private float Range = 3;
    private bool CanMove;

    private Transform View;
    private Vector2 DirectionMove;

    private Transform TargetPosition;
    private Vector2 TargetDirection;
    private Vector2 TargetDirectionNormalized;

    [SerializeField]
    private CircleCollider2D RangZoneAggression;

    [Inject]
    public void Construct(IMessage message)
    {
        iMessage = message;
    }

    public void SetTarget(Person newTarget)
    {
        Target = newTarget;
        if (Target != null) TargetPosition = newTarget.transform;
    }

    private void Awake()
    {
        View = transform.Find("View");
        presenter.SetSetting(model, this, move, scrObjModel);
        RangZoneAggression.radius = Range;
    }

    private void Update()
    {
        AIController();
        Move();
    }

    private void AIController()
    {
        if (Target != null)
        {
            TargetDirection = new Vector2(TargetPosition.position.x, TargetPosition.position.y) - new Vector2(transform.position.x, transform.position.y);
            TargetDirectionNormalized = TargetDirection.normalized;
            DirectionMove = TargetDirectionNormalized;
            CanMove = true;
        }
        else CanMove = false;
    }

    private void Move()
    {
        if (move != null && CanMove) move.OnMove(transform, DirectionMove);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroView>())
        {
            iMessage.MessageOne("Enemy: Ai, it hurts me");
            var takeDamege = UnityEngine.Random.Range(1, 7);
            OnTakeDamage(takeDamege);
            iMessage.MessageOne($"Enemy: Takes damage - {takeDamege}");
        }
    }

    public override void HealthAnimation(int curHealth) { return; }

    public override void Death()
    {
        Destroy(gameObject);
        iMessage.MessageOne("Enemy: You defeated me, khe");
    }

    public void NewPosition(Vector3 transform)
    {
        gameObject.transform.position = transform;
    }

    public class Factory : PlaceholderFactory<EnemyView> { }
}
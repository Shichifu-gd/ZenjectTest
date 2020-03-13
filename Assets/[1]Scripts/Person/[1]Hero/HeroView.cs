using Cinemachine;
using UnityEngine;
using Zenject;
using System;

public class HeroView : Person
{
    private IMessage iMessage;

    private CinemachineVirtualCamera Camera;
    [Inject]
    private PlayerBar playerBar;
    [SerializeField]
    private ScrObjModel scrObjModel;
    [SerializeField]
    private Move move;

    private Presenter presenter = new Presenter();
    private Model model = new Model();

    public override event Action<int> OnTakeDamage;

    private int DirectionLook = 1;

    private Transform View;
    private Vector2 DirectionMove;

    [Inject]
    public void Construct(IMessage message, CinemachineVirtualCamera cinemachineVirtualCamera)
    {
        iMessage = message;
        Camera = cinemachineVirtualCamera;
    }

    private void Awake()
    {
        View = transform.Find("View");
        presenter.SetSetting(model, this, move, scrObjModel);
        playerBar.AssignValues(model.GetMaxHealth());
        Camera.Follow = transform;
    }

    private void Update()
    {
        PlayerController();
        Move();
        Turn();
    }

    private void PlayerController()
    {
        DirectionMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        if (move != null) move.OnMove(transform, DirectionMove);
    }

    private void Turn()
    {
        if (DirectionMove.x != 0) DirectionLook = DirectionMove.x > 0 ? 1 : -1;
        View.localScale = new Vector3(DirectionLook, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyView>()) TakeDamage(UnityEngine.Random.Range(1, 7));
    }

    public override void TakeDamage(int takeDamege)
    {
        OnTakeDamage(takeDamege);
        iMessage.MessageOne($"<color=blue>Hero</color>: Takes damage - {takeDamege}");
    }

    public override void HealthAnimation(int curHealth)
    {
        playerBar.SetHealthBar(curHealth);
    }

    public void NewPosition(Vector3 transform)
    {
        gameObject.transform.position = transform;
    }

    public override void Death()
    {
        gameObject.SetActive(false); // TODO: FiXME
        iMessage.MessageOne("<color=blue>Hero</color>: i seem to see the light at the end of the tunnel");
    }

    public class Factory : PlaceholderFactory<HeroView> { }
}
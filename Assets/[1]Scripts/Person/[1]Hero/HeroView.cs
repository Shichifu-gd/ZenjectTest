using UnityEngine;
using System;

public class HeroView : Person
{
    [SerializeField] private ScrObjModel scrObjModel;
    private Presenter presenter = new Presenter();
    private Model model = new Model();
    public Move move;

    public override event Action<int> OnTakeDamage;

    private int DirectionLook = 1;

    private Transform View;

    private Vector2 DirectionMove;

    private void Awake()
    {
        View = transform.Find("View");
        presenter.SetSetting(model, this, move, scrObjModel);
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
        move.OnMove(transform, DirectionMove);
    }

    private void Turn()
    {
        if (DirectionMove.x != 0) DirectionLook = DirectionMove.x > 0 ? 1 : -1;
        View.localScale = new Vector3(DirectionLook, 1, 1);
    }

    public override void HealthAnimation(int curhealth, int maxHealth) { return; }

    public override void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyView>())
        {
            OnTakeDamage(UnityEngine.Random.Range(1, 7));
        }
    }
}
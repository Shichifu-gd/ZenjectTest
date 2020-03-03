using System.Collections.Generic;
using System.Collections;
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

    public override event Action<int> OnTakeDamage;

    private int DirectionLook = 1;

    private Transform View;
    private Vector2 DirectionMove;

    [Inject]
    public void Construct(IMessage message)
    {
        iMessage = message;
    }

    private void Awake()
    {
        View = transform.Find("View");
        presenter.SetSetting(model, this, move, scrObjModel);
    }

    public override void HealthAnimation(int curhealth, int maxHealth) { return; }

    public override void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroView>())
        {
            iMessage.MessageOne("Enemy: ai, it hurts me");
            OnTakeDamage(UnityEngine.Random.Range(1, 7));
        }
    }

    public void NewPosition(Vector3 transform)
    {
        gameObject.transform.position = transform;
    }

    public class Factory : PlaceholderFactory<EnemyView> { }
}
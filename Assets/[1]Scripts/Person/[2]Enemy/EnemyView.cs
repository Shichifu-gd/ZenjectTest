using UnityEngine;
using System;

public class EnemyView : Person
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
            OnTakeDamage(UnityEngine.Random.Range(1, 7));
        }
    }
}
using UnityEngine;

public class MoveVersion1 : Move
{
    private float MoveSpeed;

    public override void SetMove(ScrObjModel scrObjModel) { MoveSpeed = scrObjModel.Speed; }

    public override void OnMove(Transform currentTransform, Vector2 directionMove)
    {
        var move = directionMove * MoveSpeed;
        var speedy = directionMove.x != 0 && directionMove.y != 0 ? 0.7f : 1.0f;
        move *= speedy;
        currentTransform.Translate(move * Time.deltaTime);
    }
}
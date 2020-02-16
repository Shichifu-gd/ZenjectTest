using UnityEngine;

public class Move : MonoBehaviour
{
    public virtual void SetMove(ScrObjModel scrObjModel) { }
    public virtual void OnMove(Transform currentTransform, Vector2 directionMove) { }
}
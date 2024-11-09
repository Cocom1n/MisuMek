using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObserver
{
    void OnMove(Vector2 direction);
    void OnJump();
}


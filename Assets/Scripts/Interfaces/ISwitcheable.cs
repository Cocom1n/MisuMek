using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitcheable
{
    void SetActive(bool isActive);
    bool IsActive();
}


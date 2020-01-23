﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.GetMapManager().FinishIsReached(other.gameObject);
    }
}

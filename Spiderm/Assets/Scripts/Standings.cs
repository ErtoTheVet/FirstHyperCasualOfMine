using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Standings : MonoBehaviour
{
    [SerializeField] private List<Transform> opponents = new List<Transform>();
    [SerializeField] private Transform player;
    public TMP_Text positionNum;
    [SerializeField] private Transform endZone;
    public bool isGameEnd;

    private void FixedUpdate()
    {
        Positions();
    }

    private void Positions()
    {
        if (isGameEnd)
        {
            return;
        }
        int rank = opponents.Count + 1;

        float playerToFinish = Vector3.Distance(player.position, endZone.position);
        foreach (var opponentTransform in opponents)
        {
            float opponentToFinish = Vector3.Distance(opponentTransform.position, endZone.position);

            if (opponentToFinish >= playerToFinish)
            {
                rank--;
            }
            positionNum.text = $"Your position is {rank}";
        }
    }
}

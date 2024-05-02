using System.Collections.Generic;
using hw2.task2;
using UnityEngine;

public class AssetHub : MonoBehaviour
{
    [SerializeField] private NPCTarget _home;
    [SerializeField] private NPCTarget _mine;
    private Dictionary<NPCTargetType, NPCTarget> _npcTargets;

    public Dictionary<NPCTargetType, NPCTarget> NPCTargets => _npcTargets;

    public void Initialize()
    {
        _npcTargets = new Dictionary<NPCTargetType, NPCTarget>
        {
            {NPCTargetType.Home, _home},
            {NPCTargetType.Mine, _mine}
        };
    }
}
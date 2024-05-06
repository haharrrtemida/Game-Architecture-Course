using UnityEngine;

namespace hw2.task2.NPC
{
    public class NPCTarget : MonoBehaviour
    {
        [SerializeField] private NPCTargetType _type;
        [SerializeField] private Transform _point;

        public NPCTargetType TargetType => _type;
        public Vector3 Position => _point.position;
    }
}
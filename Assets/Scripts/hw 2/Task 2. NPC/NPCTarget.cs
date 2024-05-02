using UnityEngine;

namespace hw2.task2
{
    public class NPCTarget : MonoBehaviour
    {
        [SerializeField] private NPCTargetType _type;

        public NPCTargetType TargetType => _type;
        public Vector3 Position => transform.position;
    }
}
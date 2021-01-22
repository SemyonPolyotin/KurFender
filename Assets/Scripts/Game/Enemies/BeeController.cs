using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace Game.Enemies
{
    public class BeeController : EnemyController
    {
        [SerializeField] private List<GameObject> _waypointGoList = default;

        private void Start()
        {
            Initialize(_waypointGoList);
        }

        public void Initialize(List<GameObject> waypointGoList)
        {
            var blackboard = GetComponent<Blackboard>();
            blackboard.SetVariableValue("ThisBee", gameObject);
            if (waypointGoList == null || waypointGoList.Count == 0)
            {
                waypointGoList = CreatSimpleWay();
            }
            blackboard.SetVariableValue("BeeWaypoints", waypointGoList);
        }

        public List<GameObject> CreatSimpleWay()
        {
            var beePosition = gameObject.transform.position;
            var position1 = beePosition + Vector3.forward * 1f;
            var position2 = beePosition + Vector3.back * 1f;
            var position3 = beePosition + Vector3.right * 1f;
            var waypointList = new List<Vector3>() {position1, position2, position3};
            var result = new List<GameObject>();
            for (var index = 0; index < waypointList.Count; index++)
            {
                var waypointPosition = waypointList[index];
                var go = new GameObject($"BeeWaypoint {index}");
                go.transform.position = waypointPosition;
                result.Add(go);
            }

            return result;
        }
    }
}
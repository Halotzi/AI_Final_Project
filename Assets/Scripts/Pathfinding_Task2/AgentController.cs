using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinding{
    [RequireComponent(typeof(PathFindingAlgorithm))]
    [RequireComponent(typeof(PathFollower))]
    public class AgentController : MonoBehaviour
    {
        private PathFindingAlgorithm pathFinding;
        private PathFollower pathFollower;
        public Transform target;
        public float targetMoveSpeed = 5;
        public bool debugPath = false;
        private List<Node> path;
        void Start()
        {
            pathFinding = GetComponent<PathFindingAlgorithm>();
            pathFollower = GetComponent<PathFollower>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F)){
                path = pathFinding.FindPath(transform.position,target.position);
                pathFollower.Follow(path);
            }
            ControlTarget();
        }

        private void ControlTarget()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector3.back;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector3.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector3.right;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                direction += Vector3.up;
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                direction += Vector3.down;
            }

            target.position += direction * targetMoveSpeed * Time.deltaTime;
        }
    
        void OnDrawGizmos(){
            if(!debugPath){
                return;
            }
        
            if(path != null){
                foreach(Node node in path){
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(node.worldPosition, .5f);
                }
            }
        }
    }    
}

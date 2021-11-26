using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Simple patrol behavior.
	/// This will set the destination on the agent so that it moves through the sequence of objects in the <see cref="targets"/> array.
	/// Upon reaching a target it will wait for <see cref="delay"/> seconds.
	///
	/// See: <see cref="Pathfinding.AIDestinationSetter"/>
	/// See: <see cref="Pathfinding.AIPath"/>
	/// See: <see cref="Pathfinding.RichAI"/>
	/// See: <see cref="Pathfinding.AILerp"/>
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
	public class Patrol : VersionedMonoBehaviour {
		/// <summary>Target points to move to in order</summary>
		public Transform[] targets;
		[SerializeField] private Transform[] waypoints;

		/// <summary>Time in seconds to wait at each target</summary>
		public float delay = 0;
		public float chaseDuration = 2f;
		public float enemyRadius = 3f;
		public LayerMask playerLayerMask;

		/// <summary>Current target index</summary>
		int index;

		IAstarAI agent;
		float switchTime = float.PositiveInfinity;

		protected override void Awake () {
			base.Awake();
			agent = GetComponent<IAstarAI>();
		}

		void Start() {
			waypoints = targets;
		}

		/// <summary>Update is called once per frame</summary>
		void Update () {

			if (targets.Length == 0) return;
			
			CheckPlayerInRange();
			
			Patrolling();
			
		}

		void Patrolling() {		

			bool search = false;

			// Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
			// if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
			if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) {
				switchTime = Time.time + delay;
			}

			if (Time.time >= switchTime) {
				index = index + 1;
				search = true;
				switchTime = float.PositiveInfinity;
			}

			index = index % targets.Length;
			agent.destination = targets[index].position;

			if (search) agent.SearchPath();
		}

		public void CheckPlayerInRange() 
		{
			Transform playerTransform = null;
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemyRadius, playerLayerMask);
			if(colliders != null)
			{
				foreach(Collider2D c in colliders)
				{
					if(c.transform.tag == "Player")
					{
						RaycastHit2D hit = Physics2D.Linecast(transform.position, c.transform.position, playerLayerMask);
						if(hit.collider.tag == "Player")
						{
							playerTransform = hit.transform;
						}
					}
				}
			}
			if(playerTransform != null)
			{
				SetTargets(new Transform[] {playerTransform});
			}
			else{
				SetTargets(waypoints);
			}
		}

		IEnumerator ChaseCoroutine(Transform toChaseTransform)
		{
			SetTargets( new Transform[] {toChaseTransform});
			yield return new WaitForSeconds(chaseDuration);
			SetTargets(waypoints);
		}

		public void SetTargets(Transform[] newTargets) 
		{
			targets = newTargets;
		}

		 void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, enemyRadius);
		}


	}
}

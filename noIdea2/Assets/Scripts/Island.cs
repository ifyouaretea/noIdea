using UnityEngine;
using System.Collections;

public class IslandScript : MonoBehaviour {

	public class Island{
		string _owner; //'player', 'ai', 'neutral'
		char _size;
		int _capacity;
		private bool _generate;

		public bool generate {
			get { return _generate; }
			set { this._generate = value; }
		}

		public string owner {
			get { return _owner; }
			set { this._owner = value; }
		}

		public int capacity {
			get { return _capacity; }
			set { this._capacity = value; }
		}

		public char size {
			get { return _size; }
			set { this._size = value; 
				if (_size == 's')
					this.capacity = 10;
				else if (_size == 'm')
					this._capacity = 15;
				else if (_size == 'l')
					this._capacity = 20;
			}
		}
	}

	public GameObject isle;
	// Use this for initialization
	void Start () {
		Vector3 playerhome = new Vector3(-250, 0, 0);
		createIsland("player",'m',playerhome);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createIsland(string owner, char size, Vector3 pos){
		GameObject clone = Instantiate(isle, pos, Quaternion.identity) as GameObject;
	}
}

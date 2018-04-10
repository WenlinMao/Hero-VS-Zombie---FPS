using UnityEngine;
using System.Collections;

public class AutoCreateEthan : MonoBehaviour {

	public GameObject createGameObject;		//自动生成的游戏对象
	public float createTime = 5.0f;	//生成时间，下次以生成游戏对象的时间
	public float createDist = 40;	//生成距离，下次生成游戏对象的最大距离

	private float timer;		//生成时间间隔，记录从上次生成游戏对象到现在经过的时间


	//初始化，参数初始化
	void Start () {
		timer = 0.0f;			//将生成时间间隔清零
	}

	//每帧执行，用于在随机时间内自动生成游戏对象
	void Update () {
		//若游戏状态不是游戏进行（Playing），则不生成游戏对象
		if (GameManager.gm != null 
			&& GameManager.gm.gameState != GameManager.GameState.Playing)	
			return;
		timer += Time.deltaTime;	//更新生成时间间隔，增加上一帧所花费的时间
		if (timer >= createTime) {	//当生成时间间隔大于等于生成时间时
			CreateObject ();		//调用CreateObject生成游戏对象
			timer = 0.0f;			//将生成时间间隔清零
		}
	}

	//生成游戏对象函数
	void CreateObject(){	
		Vector3 deltaVector = new Vector3 (0.0f, 0.0f, 0.0f);	//生成位置偏差向量
		deltaVector.x = Random.Range(-createDist, createDist);
		deltaVector.z = Random.Range(-createDist, createDist);

		GameObject newGameObject = Instantiate (				//生成游戏对象
			createGameObject, 					//生成游戏对象的预制件
			transform.position-deltaVector, 	//生成游戏对象的位置，为该脚本所在游戏对象的位置减去生成位置偏差向量
			createGameObject.transform.rotation					//生成游戏对象的朝向
		) as GameObject;
	}
}

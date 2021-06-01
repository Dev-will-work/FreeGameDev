using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	public GameObject controller;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine)
		{
			CreateController();
		}
	}

	GameObject CreateController()
	{
		Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ganfaul_m_aure Variant"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
		return controller;
	}

	public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();
	}
}
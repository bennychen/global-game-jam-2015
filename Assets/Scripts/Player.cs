using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]
	public float speed = 10f;

	[SerializeField]
	public float timeToTriggerHeartBeat = 5f;

	[SerializeField]
	public AudioSource ItemAudio;

	public AudioSource BgmAudio;
	public AudioClip normalBgm;
	public AudioClip heartbeatBgm;

	public bool IsPursuingGhost { get; private set; }
	public bool IsFreezed { get; private set; }

	public void StartPursueGhost()
	{
		IsPursuingGhost = true;
	}

	public void Reset()
	{
		IsPursuingGhost = false;
		IsFreezed = false;
	}

	public void FreezePlayer(float seconds)
	{
		if (!IsFreezed)
		{
			StartCoroutine(FreezePlayerCoroutine(seconds));
		}
	}

	public IEnumerator FreezePlayerCoroutine(float seconds)
	{
		IsFreezed = true;
		yield return new WaitForSeconds(seconds);
		IsFreezed = false;
	}

	private void FixedUpdate()
	{
		if (IsFreezed) return;

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		bool changeToHeart = true;
		AudioSource source = GetComponent<AudioSource>();
		if (Mathf.Abs(moveHorizontal) > 0.1f || Mathf.Abs(moveVertical) > 0.1f)
		{
			if (!source.isPlaying)
				GetComponent<AudioSource>().Play();
			_stayStillTime = 0;
		}
		else
		{
			_stayStillTime += Time.fixedDeltaTime;
			if (_stayStillTime > 0.5f)
			{
				GetComponent<AudioSource>().Stop();

				if (_stayStillTime > timeToTriggerHeartBeat)
				{
					changeToHeart = false;
				}
			}
		}
		if (changeToHeart)
		{
			if (BgmAudio.clip != heartbeatBgm)
			{
				BgmAudio.clip = heartbeatBgm;
				BgmAudio.Play();
			}
		}
		else
		{
			if (BgmAudio.clip != normalBgm)
			{
				BgmAudio.clip = normalBgm;
				BgmAudio.Play();
			}
		}
		//rigidbody.MovePosition(rigidbody.position + moveHorizontal * Vector3.right * Time.fixedDeltaTime * 10 + 
		                       //moveVertical * Vector3.forward * Time.fixedDeltaTime * 10);
		rigidbody.velocity = moveHorizontal * Vector3.right * speed + moveVertical * Vector3.forward * speed;
	}

	private float _stayStillTime;
}

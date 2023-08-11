using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSlamState : SpiderBaseState
{
    SpiderData _data;
    Vector3[] _spawnPoints;
    public override void EnterState(SpiderStateManager spider)
    {
        spider._anim.SetBool("Slam", true);
        _data = spider._data;
        _spawnPoints = new Vector3[Random.Range(Mathf.RoundToInt( _data._slamAmount.x),Mathf.RoundToInt( _data._slamAmount.y))];
        int playerPosRock = Random.Range(0, _spawnPoints.Length - 1);
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector3 pos;
            pos = spider._target.position;

            if (i != playerPosRock)
            {
                Vector3 offset = new Vector3(Random.Range(-_data._slamDistribution.x, _data._slamDistribution.x), 0, Random.Range(-_data._slamDistribution.y, _data._slamDistribution.y));
                pos = pos + offset;
            }

            pos.y = _data._slamHeight;
            _spawnPoints[i] = pos;

        }
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            GameObject spawnedBoulder = GameObject.Instantiate(spider._boulderPrefab, null);
            Vector3 spawnPosition = new Vector3(Mathf.Clamp(_spawnPoints[i].x, _data._boulderX.x, _data._boulderX.y), _spawnPoints[i].y, Mathf.Clamp(_spawnPoints[i].z, _data._boulderZ.x, _data._boulderZ.y));
            spider._boulders.Add(spawnedBoulder.GetComponent<BossBoulder>());
            spawnedBoulder.transform.position = spawnPosition;
        }
        spider.StartCoroutine(SwitchState(spider));
    }

    IEnumerator SwitchState(SpiderStateManager spider)
    {
        yield return new WaitForSeconds(5f);
        spider.SwitchState(spider._idleState);
    }
    public override void ExitState(SpiderStateManager spider)
    {
        spider._anim.SetBool("Slam", false);

    }

    public override void UpdateState(SpiderStateManager spider)
    {
    }
}

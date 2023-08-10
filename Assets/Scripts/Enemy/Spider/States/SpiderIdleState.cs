using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdleState : SpiderBaseState
{
    SpiderData _data;
    float _timer;
    public override void EnterState(SpiderStateManager spider)
    {
        _data = spider._data;
        _timer = Random.Range(_data._attackTimer.x, _data._attackTimer.y);
    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            if(spider._boulders.Count <= 0)
            {
                spider.SwitchState(spider._slamState);

            }
            else
            {
                spider.SwitchState(spider._grappleState);

            }


        }
    }
}

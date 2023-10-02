using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_dead : SpiderBaseState
{
    public override void EnterState(SpiderStateManager spider)
    {
        if(spider._target != null)
            spider._target.GetComponent<PlayerHealth>()._spiderDead = true;
        spider._anim.SetBool("Dead", true);
        GameObject.Find("RockPitRocks").SetActive(false);
        GameObject.Find("BossTrigger").SetActive(false);
        GameObject.Find("MusicManager").GetComponent<MusicManager>().EndBossMusic();

        if(spider._spiderItem != null)
            spider._spiderItem.SetActive(true);

    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
    }
}

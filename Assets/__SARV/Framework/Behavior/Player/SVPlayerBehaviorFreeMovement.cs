using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using UnityEngine;

namespace __SARV.Framework.Behavior
{
    [SVTitle("FreeMovement")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Allows the player to freely move through the game world")]
    [Serializable]
    public class SVPlayerBehaviorFreeMovement : SVBehaviorComponent
    {
        public override void Enter()
        {
            base.Enter();
            Argument.SARVPlayer.SharedAnimancer.Play(Identifier);
        }

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
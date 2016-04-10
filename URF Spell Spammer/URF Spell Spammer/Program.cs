﻿using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Mario_s_Lib;
using static URF_Spell_Spammer.SpellManager;
using static URF_Spell_Spammer.Menus;

namespace URF_Spell_Spammer
{
    internal static class Program
    {
        private static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            SpellManager.Init();
            Menus.Init();
            
            Game.OnUpdate += OnUpdate;
        }

        private static void OnUpdate(EventArgs args)
        {
            var target = TargetSelector.GetTarget(GetTheHighestRange(), DamageType.Mixed);
            if (target != null)
            {
                //Q
                if (Skillshots.Contains(Q))
                {
                    var qSS = Q as Spell.Skillshot;
                    qSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("qHitChance"));
                }
                else
                {
                    Q.TryToCast(target, FirstMenu);
                }
                //W
                if (Skillshots.Contains(W))
                {
                    var wSS = W as Spell.Skillshot;
                    wSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("wHitChance"));
                }
                else
                {
                    W.TryToCast(target, FirstMenu);
                }
                //E
                if (Skillshots.Contains(E))
                {
                    var eSS = E as Spell.Skillshot;
                    eSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("eHitChance"));
                }
                else
                {
                    E.TryToCast(target, FirstMenu);
                }
                //R
                if (Skillshots.Contains(R))
                {
                    var rSS = R as Spell.Skillshot;
                    rSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("rHitChance"));
                }
                else
                {
                    R.TryToCast(target, FirstMenu);
                }
            }
            else
            {
                try
                {
                    if (FirstMenu.GetCheckBoxValue("qUse") && Q.IsReady()) Q.Cast(Game.CursorPos);
                    if (FirstMenu.GetCheckBoxValue("wUse") && W.IsReady()) W.Cast(Game.CursorPos);
                    if (FirstMenu.GetCheckBoxValue("eUse") && E.IsReady()) E.Cast(Game.CursorPos);
                    if (FirstMenu.GetCheckBoxValue("rUse") && R.IsReady()) R.Cast(Game.CursorPos);
                }
                catch (Exception)
                {
                    if (FirstMenu.GetCheckBoxValue("qUse") && Q.IsReady()) Q.Cast();
                    if (FirstMenu.GetCheckBoxValue("wUse") && W.IsReady()) W.Cast();
                    if (FirstMenu.GetCheckBoxValue("eUse") && E.IsReady()) E.Cast();
                    if (FirstMenu.GetCheckBoxValue("rUse") && R.IsReady()) R.Cast();
                }
            }
        }
    }
}
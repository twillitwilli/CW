using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerName;
    public int saveFile;
    public float[] playerPosition;

    // Player Stats

    public int
        maxHealth,
        currentGold,
        maxGold,
        maxMana,
        currentMagicKnives,
        maxMagicKnives;

    // Player Progression

    public bool
        hasSpear,
        hasGuard,
        hasMagicKnifePouch,
        hasFireCrystal,
        hasGhostStaff,
        hasBookOfTruth,
        hasGravityCrystal,
        hasPortalCrystal,
        hasMagicHourglass,
        hasMagic;
}

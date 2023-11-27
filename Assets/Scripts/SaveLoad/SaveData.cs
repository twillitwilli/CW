using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerName;
    public float[] playerPosition;

    public int
        saveFile,
        saveLocation;

    public bool[] chestsObtained;

    public bool randomizerMode;

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
        hasScythe,
        hasTheForgottenScythe,
        hasMagicGlove,
        hasMagicKnifePouch,
        hasFireCrystal,
        hasGhostStaff,
        hasBookOfTruth,
        hasGravityCrystal,
        hasPortalCrystal,
        hasMagicHourglass;
}

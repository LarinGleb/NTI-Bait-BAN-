using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    enum SkillsType {ADD_DAMAGE, ADD_SPEED, ADD_FASTER_RELOAD, MORE_PATRONS}

    struct Skill {
        SkillsType type;
        int countPercentToAdd;

        public SkillsType TypeSkill {
            get {return type;}
        } 
        public int PercentAdd {
            get {return countPercentToAdd;}
        }

        public float NewCharacteristick(float oldValue) {
            return oldValue * (1 + countPercentToAdd / 100);
        }
    }
}

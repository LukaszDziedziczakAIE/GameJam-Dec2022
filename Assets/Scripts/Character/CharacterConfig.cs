using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public bool active { get; set; }
    [field: SerializeField] public int voiceRef { get; set; }
    [field: SerializeField] public int helmetRef { get; set; }
    [field: SerializeField] public int armourColourRef { get; set; }
    [field: SerializeField] public int weaponRef { get; set; }
    [field: SerializeField] public List<CharacterCodeBlock> CodeBlocks { get; set; } = new List<CharacterCodeBlock>();

    public void Clear()
    {
        active = false;
        voiceRef = 0;
        helmetRef = 0;
        armourColourRef = 0;
        CodeBlocks.Clear();
    }

    [System.Serializable]
    public class CharacterCodeBlock
    {
        public ProgrammingObjectConfig CodeConfig;
        public Vector3 Position;

        public CharacterCodeBlock(CodeBlock codeBlock)
        {
            CodeConfig = codeBlock.config;
            Position = codeBlock.transform.position;
        }
    }

    public void AddCodeBlock(CodeBlock newCodeBlock)
    {
        if (!HasCodeBlock(newCodeBlock.CodeName)) return;

        CharacterCodeBlock block = new CharacterCodeBlock(newCodeBlock);
        CodeBlocks.Add(block);
    }

    public bool HasCodeBlock(string CodeBlockName)
    {
        if (CodeBlocks.Count > 0)
        {
            foreach(CharacterCodeBlock codeBlock in CodeBlocks)
            {
                if (codeBlock.CodeConfig.ObjectName == CodeBlockName) return true;
            }
        }

        return false;
    }
}

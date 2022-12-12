using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlockDetector : MonoBehaviour
{
    [SerializeField] List<CodeBlock> codeBlocks = new List<CodeBlock>();
    GameController Game;

    private void Awake()
    {
        Game = GetComponentInParent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CodeBlock>(out CodeBlock codeBlock))
        {
            codeBlocks.Add(codeBlock);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CodeBlock>(out CodeBlock codeBlock))
        {
            codeBlocks.Remove(codeBlock);
        }
    }

    public void ClearCodeBlocks()
    {
        if (codeBlocks.Count > 0)
        {
            foreach (CodeBlock codeBlock in codeBlocks)
            {
                Destroy(codeBlock.gameObject);
            }
            codeBlocks.Clear();
        }
    }

    public void CodeBlockPlaced()
    {
        print("Code Block Placed");

        CodeBlock[] blocks = FindObjectsOfType<CodeBlock>();
        if (blocks.Length > 0)
        {
            foreach(CodeBlock codeBlock in blocks)
            {
                codeBlocks.Add(codeBlock);
            }
        }

        if (Game.HUD.Programing.currentlySelected == 0) return;

        if (codeBlocks.Count > 0)
        {
            foreach(CodeBlock codeBlock in codeBlocks)
            {
                Game.CharacterConfig[Game.HUD.Programing.currentlySelected].AddCodeBlock(codeBlock);
                /*if (!Game.CharacterConfig[Game.HUD.Programing.currentlySelected].HasCodeBlock(codeBlock.config.ObjectName))
                {
                    Game.CharacterConfig[Game.HUD.Programing.currentlySelected].AddCodeBlock(codeBlock);
                }*/
            }
        }
    }

    public void RebuildBlocks()
    {
        if (Game.HUD.Programing.currentlySelected == 0) return;
        ClearCodeBlocks();

        if (Game.CharacterConfig[Game.HUD.Programing.currentlySelected].CodeBlocks.Count > 0)
        {
            foreach(CharacterConfig.CharacterCodeBlock block in 
                Game.CharacterConfig[Game.HUD.Programing.currentlySelected].CodeBlocks)
            {
                CodeBlock newBlock = Instantiate(Game.CodeBlockPrefab, block.Position, Quaternion.Euler(Vector3.zero));
                codeBlocks.Add(newBlock);
            }
        }
    }
}

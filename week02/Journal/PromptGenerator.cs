using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What made you happy today?",
        "Describe a challenge you overcame recently.",
        "Write about someone who inspires you.",
        "What are you grateful for?",
        "Reflect on a recent mistake and lesson learned."
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
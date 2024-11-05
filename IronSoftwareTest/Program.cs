using System;
using System.Collections.Generic;
using System.Text;

public class InterviewTest
{
    // Dictionary that maps each number key to possible letters
    private static readonly Dictionary<char, string> keyMapping = new Dictionary<char, string>
    {
        {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"},
        {'5', "JKL"}, {'6', "MNO"}, {'7', "PQRS"},
        {'8', "TUV"}, {'9', "WXYZ"}, {'0', " "} //  '0' is space
    };

    public static string OldPhonePad(string input)
    {
        DateTime lastKeyPressTime = DateTime.MinValue; // Track last key press time
        StringBuilder output = new StringBuilder(); 
        int count = 0; // Counts presses for the same button
        char? currentKeyInput = null; // Current key being processed

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (HandleSpecialKeys(c, output, ref currentKeyInput, ref count))
                continue;

            DateTime currentKeyPressTime = DateTime.Now;

            if (IsContinuousPress(c, currentKeyInput, currentKeyPressTime, lastKeyPressTime)) // If the same key is pressed more than once it adds to the count
            {
                count++;
            }
            else // if it is not it returns to the beggining.
            {
                AppendCurrentCharacter(output, currentKeyInput, count);
                currentKeyInput = c;
                count = 1;
            }

            lastKeyPressTime = currentKeyPressTime;

            if (IsLastOrDifferentKey(input, i, c)) // Here it checks if the last key is different.
            {
                AppendCurrentCharacter(output, currentKeyInput, count);
                currentKeyInput = null;
                count = 0;
            }

            if (c == '#') // End of input
                break;
        }

        return output.ToString();
    }

    // Handle with a bool the special keys backspace and space
    private static bool HandleSpecialKeys(char c, StringBuilder output, ref char? currentKeyInput, ref int count)
    {
        if (c == '*')
        {
            if (output.Length > 0)
                output.Length--; // Backspace operation
            ResetKeyProcessing(ref currentKeyInput, ref count);
            return true;
        }

        if (c == ' ')
        {
            ResetKeyProcessing(ref currentKeyInput, ref count);
            return true;
        }

        return false;
    }

    // Check if the same key is pressed continuously within a second
    private static bool IsContinuousPress(char c, char? currentKeyInput, DateTime currentKeyPressTime, DateTime lastKeyPressTime)
    {
        return currentKeyInput == c && (currentKeyPressTime - lastKeyPressTime).TotalSeconds < 1;
    }

    // Check if the key pressed is the last one in the sequence or different from the next one
    private static bool IsLastOrDifferentKey(string input, int index, char c)
    {
        return index + 1 == input.Length || input[index + 1] != c;
    }

    // Append the currently processed character to the output
    private static void AppendCurrentCharacter(StringBuilder output, char? currentKeyInput, int count)
    {
        if (count > 0 && currentKeyInput.HasValue && keyMapping.ContainsKey(currentKeyInput.Value))
        {
            int index = (count - 1) % keyMapping[currentKeyInput.Value].Length;
            string letter = keyMapping[currentKeyInput.Value][index].ToString();
            output.Append(letter);
        }
    }

    // Reset key processing state
    private static void ResetKeyProcessing(ref char? currentKeyInput, ref int count)
    {
        currentKeyInput = null;
        count = 0;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

public class InterviewTest
{
// Dictionary that maps each number key to possible letters
    private static Dictionary<char, string> keyMapping = new Dictionary<char, string>
    {
        {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"},
        {'5', "JKL"}, {'6', "MNO"}, {'7', "PQRS"},
        {'8', "TUV"}, {'9', "WXYZ"}, {'0', " "} // Maps '0' to space
    };

    public static string OldPhonePad(string input)
    {
        DateTime lastKeyPressTime = DateTime.MinValue; // Pause Timer
        StringBuilder output = new StringBuilder();
        int count = 0; // Counts the number of presses for the same button
        char? currentKeyInput = null; // This will maintain the current key being processed

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            
            if (c == '*') // Handle backspace (erase last character in output)
            {
                if (output.Length > 0)
                {
                    output.Length--;
                }
 
                currentKeyInput = null;
                count = 0;
                continue;
            }

            if (c == ' ') // A way to handle space (0 in this case)
            {
                currentKeyInput = null;
                count = 0;
                continue;
            }

            DateTime currentKeyPressTime = DateTime.Now; // Variable for time handling. 

            // If there is no pause
            if (currentKeyInput == c && (currentKeyPressTime - lastKeyPressTime).TotalSeconds < 1)
            {
                count++;
            }
            else // New key pressed or pause of 1 second.
            {
                if (count > 0 && currentKeyInput.HasValue && keyMapping.ContainsKey(currentKeyInput.Value))
                {
                    int index = (count - 1) % keyMapping[currentKeyInput.Value].Length;
                    string letter = keyMapping[currentKeyInput.Value][index].ToString();
                    output.Append(letter);
                }

                currentKeyInput = c;
                count = 1;
            }

            lastKeyPressTime = currentKeyPressTime;

            if (i + 1 == input.Length || input[i + 1] != c)
            {
                if (count > 0 && currentKeyInput.HasValue && keyMapping.ContainsKey(currentKeyInput.Value))
                {
                    int index = (count - 1) % keyMapping[currentKeyInput.Value].Length;
                    string letter = keyMapping[currentKeyInput.Value][index].ToString(); 
                    output.Append(letter);
                }
                // Reset the count for the next input.
                count = 0;
                currentKeyInput = null;
            }

            if (c == '#') //This will make it the end Of Input
            {
                break;
            }
        }

        return output.ToString();
    }
}

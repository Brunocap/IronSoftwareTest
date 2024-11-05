using System;
using Xunit;

public class InterviewTestUnitTests
{
    [Fact]
    public void TestSingleLetter()
    {
        string result = InterviewTest.OldPhonePad("33#");
        Assert.Equal("E", result); // Expected output
    }

    [Fact]
    public void TestWithBackspace()
    {
        string result = InterviewTest.OldPhonePad("227*#");
        Assert.Equal("B", result); // "22" is B, then "7" is deleted
    }

    [Fact]
    public void TestMultipleLetters()
    {
        string result = InterviewTest.OldPhonePad("4433555 555666#");
        Assert.Equal("HELLO", result); // This sequence spells "HELLO"
    }

    [Fact]
    public void TestWithSpacesAndBackspace()
    {
        string result = InterviewTest.OldPhonePad("8 88777444666*664#");
        Assert.Equal("TURING", result); // This should spell "TURING"
    }
}

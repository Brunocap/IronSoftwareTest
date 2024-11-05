using System;
using Xunit;

public class InterviewTestUnitTests
{
	//Test cases that where presented.
	[Fact]
	public void TestSingleLetter()
	{
		string result = InterviewTest.OldPhonePad("33#");
		Assert.Equal("E", result);
	}

	[Fact]
	public void TestWithBackspace()
	{
		string result = InterviewTest.OldPhonePad("227*#");
		Assert.Equal("B", result);
	}

	[Fact]
	public void TestMultipleLetters()
	{
		string result = InterviewTest.OldPhonePad("4433555 555666#");
		Assert.Equal("HELLO", result);
	}

	[Fact]
	public void TestWithSpacesAndBackspace()
	{
		string result = InterviewTest.OldPhonePad("8 88777444666*664#");
		Assert.Equal("TURING", result);
	}

	[Fact]
	public void TestAlternatingKeysWithPauses()
	{
		string result = InterviewTest.OldPhonePad("2 3 2 3#"); // Alternates between '2' and '3' with pauses
		Assert.Equal("ADAD", result); // Should output the first character of each key each time
	}

	[Fact]
	public void TestEmptyInput()
	{
		string result = InterviewTest.OldPhonePad("");
		Assert.Equal("", result); // Empty input produces empty output
	}

	[Fact]
	public void TestInvalidCharacters()
	{
		string result = InterviewTest.OldPhonePad("44A33!555#"); // Includes invalid characters 'A' and '!'
		Assert.Equal("HEL", result); // Ignores invalid characters and processes only valid numbers
	}

	[Fact]
	public void TestBackspaceAtStart()
	{
		string result = InterviewTest.OldPhonePad("*#");
		Assert.Equal("", result); // No characters to delete, so output remains empty
	}

	[Fact]
	public void TestContinuousKeyPressWrap()
	{
		string result = InterviewTest.OldPhonePad("22222#"); // Pressing '2' five times
		Assert.Equal("B", result); // Wraps to 'B' (4th press is A, 5th wraps to B)
	}
}
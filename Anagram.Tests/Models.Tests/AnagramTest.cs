using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Anagram.Models;

namespace Anagram.Tests
{
  [TestClass]
  public class AnagramTest
  {
    [TestMethod]
    public void IsAnagram_IsFunctionBeingCalled_ReturnFalse()
    {
      Assert.AreEqual(false, WordSet.IsAnagram("bAcoN", "cat"));
    }
    [TestMethod]
    public void IsAnagram_AreStringComparisonWorking_FalseCase()
    {
      Assert.AreEqual(false, WordSet.IsAnagram("bAcoN", "baCOn"));
    }
    [TestMethod]
    public void IsAnagram_AreStringComparisonWorking_TrueCase()
    {
      Assert.AreEqual(true, WordSet.IsAnagram("bAt", "Tab"));
    }

    [TestMethod]
    public void GetAllAnagrams_TestOneToManyStrings_ReturnListOfMatches()
    {
      List<string> testStrings = new List<string>{"tab", "cat", "dog"};
      WordSet testSet = new WordSet("bat", testStrings);
      List<string> matchedAnagrams = new List<string>{"tab"};

      CollectionAssert.AreEqual(matchedAnagrams, testSet.GetAllAnagrams());
    }
  }
}

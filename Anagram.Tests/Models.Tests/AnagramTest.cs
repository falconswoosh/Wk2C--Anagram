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
    public void IsAnagram_WordsAreUnequal_False()
    {
      Assert.AreEqual(false, WordSet.IsAnagram("bAcoN", "cat"));
    }
    [TestMethod]
    public void IsAnagram_WordsAreEqual_False()
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

    [TestMethod]
    public void IsPartialAnagram_StringHasDuplicateLetters_False()
    {
      Assert.AreEqual(false, WordSet.IsPartialAnagram("hath", "that"));
    }
    [TestMethod]
    public void IsPartialAnagram_StringIsSubsetOfTarget_True()
    {
      Assert.AreEqual(true, WordSet.IsPartialAnagram("hat", "that"));
    }
    [TestMethod]
    public void IsPartialAnagram_StringHasMoreLettersThanTarget_False()
    {
      Assert.AreEqual(false, WordSet.IsPartialAnagram("that", "hat"));
    }

    [TestMethod]
    public void GetAllPartialAnagrams_TestOneToManyStrings_ReturnListOfPartialMatches()
    {
      List<string> testStrings = new List<string>{"tab", "table", "dog"};
      WordSet testSet = new WordSet("bat", testStrings);
      List<string> matchedAnagrams = new List<string>{"tab", "table"};

      CollectionAssert.AreEqual(matchedAnagrams, testSet.GetAllPartialAnagrams());
    }
  }
}

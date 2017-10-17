using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagram.Models
{
  public class WordSet
  {
    private string _source;
    private List<string> _targetList;

    public WordSet(string source, List<string> targetList)
    {
      _source = source;
      _targetList = targetList;
    }

    public string GetSource(){return _source;}
    public List<string> GetTarget(){return _targetList;}

    public List<string> GetAllAnagrams()
    {
      List<string> matchedAnagrams = new List<string>{};
      foreach (string word in _targetList)
      {
        if(IsAnagram(_source, word))
        {
          matchedAnagrams.Add(word);
        }
      }
      return matchedAnagrams;
    }

    public List<string> GetAllPartialAnagrams()
    {
      List<string> matchedAnagrams = new List<string>{};
      foreach (string word in _targetList)
      {
        if(IsPartialAnagram(_source, word))
        {
          matchedAnagrams.Add(word);
        }
      }
      return matchedAnagrams;
    }

    public static bool IsAnagram(string source, string target)
    {
      source = source.ToLower();
      target = target.ToLower();

      if (source == target)
      {
        return false;
      }
      else
      {
        char[] a = source.ToCharArray();
        char[] b = target.ToCharArray();
        Array.Sort(a);
        Array.Sort(b);
        if (a.SequenceEqual(b))
        {return true;}
        else
        {return false;}
      }
    }

    public static bool IsPartialAnagram(string source, string target)
    {
      int successLength = target.Length - source.Length;
      foreach (char sourceLetter in source) {
        for (int i = 0; i < target.Length; i++)
        {
          if (sourceLetter == target[i])
          {
            target = target.Remove(i, 1);
            break;
          }
        }
      }
      return (successLength == target.Length);
    }
  }
}

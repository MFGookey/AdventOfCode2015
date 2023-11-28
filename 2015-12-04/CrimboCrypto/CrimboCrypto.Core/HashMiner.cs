using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CrimboCrypto.Core
{
  public class HashMiner
  {
    private string _seed;
    private MD5CryptoServiceProvider _hashProvider;
    public HashMiner(string seed)
    {
      _hashProvider = new MD5CryptoServiceProvider();
      _hashProvider.Initialize();
      _seed = seed;
    }

    public int GetSeedModifier(Func<string, bool> evaluator)
    {
      int testValue = 0;
      string hash = string.Empty;
      do
      {
        testValue++;
        hash = this.ByteArrayToString(_hashProvider.ComputeHash(Encoding.ASCII.GetBytes($"{_seed}{testValue}")));
      } while (!evaluator(hash));
      return testValue;
    }

    public Func<string, bool> HashPrefixEvaluator(string desiredPrefix)
    {
      return (string hash) => { return hash.StartsWith(desiredPrefix, StringComparison.Ordinal); };
    }

    private string ByteArrayToString(byte[] ba)
    {
      StringBuilder hex = new StringBuilder(ba.Length * 2);
      foreach (byte b in ba)
        hex.AppendFormat("{0:x2}", b);
      return hex.ToString();
    }
  }
}

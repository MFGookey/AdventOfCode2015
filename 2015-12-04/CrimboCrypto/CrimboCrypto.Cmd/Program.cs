using System;
using Common.Utilities.IO;
using CrimboCrypto.Core;

namespace CrimboCrypto.Cmd
{
  /// <summary>
  /// The entrypoint for CrimboCrypto.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// CrimboCrypto.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      string testSeed = "abcdef";
      var miner = new HashMiner(testSeed);
      Console.WriteLine(miner.GetSeedModifier(miner.HashPrefixEvaluator("00000")));
      string seed = "yzbqklnj";
      miner = new HashMiner(seed);
      Console.WriteLine(miner.GetSeedModifier(miner.HashPrefixEvaluator("00000")));
      _ = Console.ReadLine();
    }
  }
}

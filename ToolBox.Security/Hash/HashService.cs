using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Security.Hash
{
    public class HashService
    {
        private readonly HashAlgorithm _algo;

        public HashService(HashAlgorithm algo)
        {
            _algo = algo;
        }

        public byte[] Hash(string toHash)
        {
            return _algo.ComputeHash(Encoding.UTF8.GetBytes(toHash));
        }

        public bool Compare(string value, byte[] hashed)
        {
            return Hash(value).SequenceEqual(hashed);
        }
    }
}

// CopyRight RoSchmi 2019 , License Apache 2.0

// Find a byte sequence within a byte array
// Adaption that can be used with NETMF or TinyCLR
//
// The code of this post was changed that it can be used with NETMF and TinyCLR
// https://stackoverflow.com/questions/37500629/find-byte-sequence-within-a-byte-array


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoyerMooreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] haystack = new byte[10000];
            byte[] needle = { 0x00, 0x69, 0x73, 0x6F, 0x6D };

            // Put a few copies of the needle into the haystack.

            for (int i = 1000; i <= 9000; i += 1000)
            Array.Copy(needle, 0, haystack, i, needle.Length);

            haystack[9995] = 0x6D;

            haystack[9994] = 0x6F;

            haystack[9993] = 0x73;

            haystack[9992] = 0x69;

            haystack[9991] = 0x00;

            needle = new byte[] { 0x00, 0x69, 0x73, 0x6F, 0x6D };

            var searcher = new BoyerMoore(needle);

            int[] foundIdxArray = searcher.Search(haystack, false);

            if (foundIdxArray.Length == 0)
            {
                Console.WriteLine("No match was found!");
            }
            else
            {

                foreach (int idx in foundIdxArray)
                {
                    Console.WriteLine(idx);
                }
            }
            Console.ReadKey();
        }
    }
}

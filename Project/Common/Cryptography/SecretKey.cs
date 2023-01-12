﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SecretKey
    {
		public static string GenerateKey()
		{
			SymmetricAlgorithm symmAlgorithm = AesCryptoServiceProvider.Create();
			return ASCIIEncoding.ASCII.GetString(symmAlgorithm.Key);
		}

    }
}